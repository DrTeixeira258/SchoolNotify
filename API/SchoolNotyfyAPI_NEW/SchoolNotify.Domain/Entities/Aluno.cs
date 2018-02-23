using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public int IdResponsavel { get; set; }
        public int IdSala { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }

        public virtual Responsavel Responsavel { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
