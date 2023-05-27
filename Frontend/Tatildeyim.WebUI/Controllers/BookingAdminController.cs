using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Tatildeyim.WebUI.Dtos.BookingDto;
using Tatildeyim.WebUI.Dtos.ServiceDto;

namespace Tatildeyim.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation(int id,ResultBookingDto resultBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultBookingDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            await client.PutAsync("http://localhost:5283/api/Booking/ApprovedBooking?id="+id,stringContent);
            return RedirectToAction("Index");
        }
    }
}
