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
        public virtual Responsavel Responsavel { get; set; }
        public int IdSalaProfessorRelacional { get; set; }
        public virtual SalaProfessorRelacional SalaProfessorRelacional { get; set; }
    }
}
