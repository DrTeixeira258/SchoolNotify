using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class GenericProfile : Profile
    {
        protected override void Configure()
        {
            //CreateMap<PostColaboradorViewModel, Colaborador>().ReverseMap();
        }
    }
}