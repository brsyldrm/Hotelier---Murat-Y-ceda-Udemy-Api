using AutoMapper;
using Tatildeyim.DtoLayer.Dtos.RoomDto;
using Tatildeyim.EntityLayer.Concrete;

namespace Tatildeyim.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
