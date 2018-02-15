using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public int IdResponsavel { get; set; }
        public int IdSala { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }

        public SalaViewModel Sala { get; set; }
        public ResponsavelViewModel Responsavel { get; set; }
    }
}
