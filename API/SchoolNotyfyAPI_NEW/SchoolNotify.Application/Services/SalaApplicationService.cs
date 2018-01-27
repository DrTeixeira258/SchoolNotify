using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class SalaApplicationService : BaseApplicationService, ISalaApplicationService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaApplicationService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<IEnumerable<SalaViewModel>> ObterSalas()
        {
            return Mapper.Map< IEnumerable<SalaViewModel>>(await _salaRepository.GetAll());
        }
    }
}
