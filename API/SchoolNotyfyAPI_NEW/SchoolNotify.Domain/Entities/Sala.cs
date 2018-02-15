using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Serie { get; set; }
        public virtual ICollection<SalaProfessorRelacional> SalaProfessorRelacional { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
