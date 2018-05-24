using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class TokenApplicationService : BaseApplicationService, ITokenApplicationService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenApplicationService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<bool> SalvarToken(TokenViewModel token)
        {
            try
            {
                var tokenDB = await _tokenRepository.Get(x => x.TelefoneResp == token.TelefoneResp);
                Token newToken = new Token();
                if (tokenDB.Any())
                {
                    newToken = tokenDB.FirstOrDefault();
                    newToken.UserId = token.UserId;
                    await BeginTransaction();
                    await Task.Run(() => _tokenRepository.Update(newToken));
                    await Commit();
                    return true;
                }
                else
                {
                    newToken = Mapper.Map<Token>(token);
                    await BeginTransaction();
                    await Task.Run(() => _tokenRepository.Add(newToken));
                    await Commit();
                    return true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<string>> BuscarTokensPorTelefones(IEnumerable<long> telefones)
        {
            var tokens = new List<string>();
            foreach (var telefone in telefones)
            {
                var token = (await _tokenRepository.GetReadOnly(x => x.TelefoneResp == telefone)).FirstOrDefault();
                if (token != null)
                    tokens.Add(token.UserId);
            }
            return tokens;
        }
    }
}
