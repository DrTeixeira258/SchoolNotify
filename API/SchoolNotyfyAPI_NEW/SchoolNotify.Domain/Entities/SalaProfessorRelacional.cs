using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class SalaProfessorRelacional
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public virtual Sala Sala { get; set; }
        public int IdProfessor { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
