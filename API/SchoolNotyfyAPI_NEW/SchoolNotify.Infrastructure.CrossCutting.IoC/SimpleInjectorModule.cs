﻿using SimpleInjector;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services;
using SchoolNotify.Domain.Interfaces.Repository;
using SchoolNotify.Infrastructure.Data.Context;
using SchoolNotify.Infrastructure.Data.Files;
using SchoolNotify.Infrastructure.Data.Files.Interfaces;
using SchoolNotify.Infrastructure.Data.Interfaces.Management;
using SchoolNotify.Infrastructure.Data.Repositories;
using SchoolNotify.Infrastructure.Data.UoW;

namespace SchoolNotify.Infrastructure.CrossCutting.IoC
{
    public class SimpleInjectorModule
    {
        public static void RegisterServices(Container container)
        {
            #region Application Service
            container.Register<IUploadImagemApplicationService, UploadImagemApplicationService>(Lifestyle.Scoped);

            container.Register<IResponsavelApplicationService, ResponsavelApplicationService>(Lifestyle.Scoped);
            container.Register<ISalaApplicationService, SalaApplicationService>(Lifestyle.Scoped);
            container.Register<IProfessorApplicationService, ProfessorApplicationService>(Lifestyle.Scoped);
            container.Register<IAlunoApplicationService, AlunoApplicationService>(Lifestyle.Scoped);
            container.Register<IUsuarioApplicationService, UsuarioApplicationService>(Lifestyle.Scoped);
            container.Register<INotificacaoApplicationService, NotificacaoApplicationService>(Lifestyle.Scoped);
            container.Register<ITokenApplicationService, TokenApplicationService>(Lifestyle.Scoped);
            #endregion

            #region Service
            //container.Register<IParametroService, ParametroService>(Lifestyle.Scoped);
            #endregion

            #region Repository
            container.Register<IResponsavelRepository, ResponsavelRepository>(Lifestyle.Scoped);
            container.Register<ISalaRepository, SalaRepository>(Lifestyle.Scoped);
            container.Register<ISalaProfessorRelacionalRepository, SalaProfessorRelacionalRepository>(Lifestyle.Scoped);
            container.Register<IProfessorRepository, ProfessorRepository>(Lifestyle.Scoped);
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<INotificacaoRepository, NotificacaoRepository>(Lifestyle.Scoped);
            container.Register<ITokenRepository, TokenRepository>(Lifestyle.Scoped);
            #endregion

            #region Data Config
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IContextManager, ContextManager>(Lifestyle.Scoped);
            #endregion

            #region DAO
            container.Register<IFileDAO, FileDAO>(Lifestyle.Scoped);
            #endregion
        }
    }
}
