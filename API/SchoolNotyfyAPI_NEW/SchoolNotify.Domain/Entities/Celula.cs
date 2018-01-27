using System.Collections.Generic;

namespace Domain.Entities
{
    public class Celula
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public bool Cancelada { get; set; }
        public virtual ICollection<CelulaUnidadeRelacional> CelulaUnidadeRelacional { get; set; }
    }
}
