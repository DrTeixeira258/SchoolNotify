using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CelulaUnidadeRelacional
    {
        public int Id { get; set; }
        public int CelulaId { get; set; }
        public virtual Celula Celula { get; set; }
        public int UnidadeId { get; set; }
        //    public virtual Unidade Unidade { get; set; }
        //    public virtual ICollection<Colaborador> Colaboradores { get; set; }
        //    public virtual ICollection<Colaborador> Supervisores { get; set; }
    }
}
