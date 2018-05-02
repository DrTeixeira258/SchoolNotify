using SchoolNotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.ViewModels
{
    public class NotificacaoViewModel
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public int? IdSala { get; set; }
        public int? IdAluno { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public ProfessorViewModel Professor { get; set; }
        public SalaViewModel Sala { get; set; }
        public AlunoViewModel Aluno { get; set; }

    }
}
