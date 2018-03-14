using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int? Telefone { get; set; }
        public bool? Responsavel { get; set; }
        public bool? Professor { get; set; }
        public bool? Admin { get; set; }
    }
}
