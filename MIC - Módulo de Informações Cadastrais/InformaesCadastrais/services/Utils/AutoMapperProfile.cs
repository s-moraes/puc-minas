using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UsuarioModel>();
            CreateMap<RegistroModel, User>();
            CreateMap<UsuarioUpdateModel, User>();
        }
    }
}