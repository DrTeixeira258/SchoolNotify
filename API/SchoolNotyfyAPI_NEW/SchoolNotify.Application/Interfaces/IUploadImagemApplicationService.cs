﻿using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface IUploadImagemApplicationService
    {
        Task<UploadImagemViewModel> UploadImagem(UploadImagemViewModel imagem);
        Task DeletarImagem(string path, int id, string name);
    }
}
