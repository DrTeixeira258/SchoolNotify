﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Responsavel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
