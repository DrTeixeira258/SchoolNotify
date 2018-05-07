using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public long TelefoneResp { get; set; }
    }
}
