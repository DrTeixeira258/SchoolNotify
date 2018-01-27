using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Models
{
    public class FileItem
    {
        public string Name { get; set; }
        public string MyProperty { get; set; }
        public string FileEncoded { get; set; }
        public byte[] FileBytes { get; set; }
        public long Length { get; set; }
    }
}
