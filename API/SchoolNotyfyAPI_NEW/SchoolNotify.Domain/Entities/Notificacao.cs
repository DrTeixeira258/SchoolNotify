using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public int? IdSala { get; set; }
        public int? IdAluno { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
