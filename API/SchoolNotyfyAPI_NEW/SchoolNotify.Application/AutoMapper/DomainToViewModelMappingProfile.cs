using AutoMapper;
using Domain.Entities;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;
using System;

namespace SchoolNotify.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region SchoolNotify
            Mapper.CreateMap<Celula, CelulaViewModel>();
            Mapper.CreateMap<Sala, SalaViewModel>();
            Mapper.CreateMap<Professor, ProfessorViewModel>();
            Mapper.CreateMap<Responsavel, ResponsavelViewModel>();
            #endregion
        }
    }
}
