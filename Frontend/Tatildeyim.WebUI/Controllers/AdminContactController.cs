using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Text;
using Tatildeyim.WebUI.Dtos.ContactDto;
using Tatildeyim.WebUI.Dtos.SendMessageDto;
using Tatildeyim.WebUI.Models.Staff;

namespace Tatildeyim.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PartialViewResult> SideBarAdminContactPartial()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Contact/GetContactCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.contactCount = jsonData;
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5283/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SendMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5283/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetSendMessageByIDDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "admin@admin.com";
            createSendMessageDto.SenderName = "Admin";
            createSendMessageDto.Date = Convert.ToDateTime(DateTime.Now.ToString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5283/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                MimeMessage mimeMessage = new MimeMessage();
                //Kimin yolladığına dair bilgiler
                MailboxAddress mailboxAdressFrom = new MailboxAddress("TatildeyimAdmin", "Mail adresi");
                mimeMessage.From.Add(mailboxAdressFrom);

                //kime yollanıldığına dair bilgiler
                MailboxAddress mailboxAddressTo = new MailboxAddress(createSendMessageDto.ReceiverName, createSendMessageDto.ReceiverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                //yollanılan mesaj
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = createSendMessageDto.Content;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                //yollanılan mesajın başlığı/konusu
                mimeMessage.Subject = createSendMessageDto.Title;

                //smtp bağlantısı ve yollama işlemi
                SmtpClient server = new SmtpClient();
                server.Connect("smtp.gmail.com", 587, false);
                server.Authenticate("mail adresi", "uygulama şifresi");
                server.Send(mimeMessage);
                server.Disconnect(true);

                return RedirectToAction("SendBox");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetContactCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/GetContactCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
