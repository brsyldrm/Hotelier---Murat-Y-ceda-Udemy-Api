using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Tatildeyim.BusinessLayer.Abstract;
using Tatildeyim.DataAccessLayer.Concrete;
using Tatildeyim.WebApi.Models;

namespace Tatildeyim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult AppUserListWithWorkLocation()
        {
            Context context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            {
                Name=y.Name,
                Surname=y.Surname,
                WorkLocationID=y.WorkLocationID,
                WorkLocationName = y.WorkLocation.WorkLocationName,
                City=y.City,
                ImageUrl=y.ImageUrl
            }).ToList();
            return Ok(values);
        }
        [HttpGet("AppUserList")]
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
    }
}
