using AutoMapper;
using Domain.Entities;
using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.AutoMapper.CustomProfiles.ModelToViewModel
{
    public class ColaboradorParaColaboradorPorInstituicaoViewModelCustomProfile : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<Colaborador, ColaboradorPorInstituicaoViewModel>()
            //    .ForMember(src => src.NomeColaborador, opt => opt.MapFrom(x => x.Nome))
            //    .ForMember(src => src.NomeInstituicao, opt => opt.MapFrom(x => x.Curso.InstituicaoEnsino.Nome))
            //    .ForMember(src => src.NumeroCelula, opt => opt.MapFrom(x => x.CelulaUnidadeRelacional.Celula.Numero))
            //    .ForMember(src => src.Cargo, opt => opt.MapFrom(x => x.Cargo.Nome));
        }
    }
}
