using AutoMapper;
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
            Mapper.CreateMap<Sala, SalaViewModel>();
            Mapper.CreateMap<Professor, ProfessorViewModel>();
            Mapper.CreateMap<Responsavel, ResponsavelViewModel>();
            Mapper.CreateMap<Aluno, AlunoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Notificacao, NotificacaoViewModel>();
            #endregion
        }
    }
}
