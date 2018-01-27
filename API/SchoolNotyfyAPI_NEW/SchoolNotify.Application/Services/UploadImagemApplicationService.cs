using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Infrastructure.Data.Files.Interfaces;
using SchoolNotify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class UploadImagemApplicationService : BaseApplicationService, IUploadImagemApplicationService
    {
        public readonly IFileDAO _fileDAO;
        public UploadImagemApplicationService(IFileDAO fileDAO)
        {
            _fileDAO = fileDAO;
        }

        public async Task<UploadImagemViewModel> UploadImagem(UploadImagemViewModel imagem)
        {
            try
            {
                if (imagem.FileReplace)
                {
                    await DeletarImagem(imagem.Path, imagem.ClienteId, imagem.Name);
                }

                var nome = _fileDAO.FileUpload(imagem.Path + imagem.ClienteId, Mapper.Map<FileItem>(imagem));
                imagem.StatusUpload = true;
            }
            catch (Exception e)
            {
                imagem.Excecao = e.ToString();
                imagem.StatusUpload = false;
            }

            return imagem;
        }

        public async Task DeletarImagem(string path, int id, string name)
        {
            await Task.Run(() => _fileDAO.Delete(path + id, name));
        }
    }
}
