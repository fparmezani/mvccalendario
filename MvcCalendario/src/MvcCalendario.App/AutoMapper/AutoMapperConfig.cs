using AutoMapper;
using MvcCalendario.App.ViewModels;
using MvcCalendario.Business.Models;

namespace MvcCalendario.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
