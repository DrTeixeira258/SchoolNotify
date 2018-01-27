using SchoolNotify.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Validation
{
    public class ValidationApplicationResult
    {
        public ValidationApplicationResult()
        {
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; set; }
        public string Message { get; set; }
        public bool IsValid
        {
            get
            {
                return Errors.Count == 0;
            }
        }
    }
}
