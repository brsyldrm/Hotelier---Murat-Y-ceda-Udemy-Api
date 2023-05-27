using Tatildeyim.EntityLayer.Concrete;
using Tatildeyim.WebUI.Dtos.ServiceDto;
using AutoMapper;
using Tatildeyim.WebUI.Dtos.RegisterDto;
using Tatildeyim.WebUI.Dtos.LoginDto;
using Tatildeyim.WebUI.Dtos.AboutDto;
using Tatildeyim.WebUI.Dtos.TestimonialDto;
using Tatildeyim.WebUI.Dtos.StaffDto;
using Tatildeyim.WebUI.Dtos.SubscribeDto;
using Tatildeyim.WebUI.Dtos.BookingDto;
using Tatildeyim.WebUI.Dtos.GuestDto;
using Tatildeyim.WebUI.Dtos.AppUserDto;

namespace Tatildeyim.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();
            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();

            CreateMap<ResultTestimonialDto,Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto,Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<StatusBookingDto, Booking>().ReverseMap();

            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
        }
    }
}
