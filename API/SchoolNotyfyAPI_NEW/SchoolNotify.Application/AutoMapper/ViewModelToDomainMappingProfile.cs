using AutoMapper;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;

namespace SchoolNotify.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region SchoolNotify
            Mapper.CreateMap<SalaViewModel, Sala>();
            Mapper.CreateMap<ProfessorViewModel, Professor>();
            Mapper.CreateMap<ResponsavelViewModel, Responsavel>();
            Mapper.CreateMap<AlunoViewModel, Aluno>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<NotificacaoViewModel, Notificacao>();
            Mapper.CreateMap<TokenViewModel, Token>();
            #endregion
        }
    }
}
