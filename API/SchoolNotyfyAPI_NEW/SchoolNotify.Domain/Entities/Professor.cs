﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Email { get; set; }
        public virtual ICollection<SalaProfessorRelacional> SalaProfessorRelacional { get; set; }
    }
}