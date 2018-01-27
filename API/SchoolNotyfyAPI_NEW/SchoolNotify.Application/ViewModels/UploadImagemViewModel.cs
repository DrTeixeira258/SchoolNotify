using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.ViewModels
{
    public class UploadImagemViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Name { get; set; }
        public string NewName { get; set; }
        public string FileEncoded { get; set; }
        public byte[] FileBytes { get; set; }
        public long Length { get; set; }
        public bool StatusUpload { get; set; }
        public List<string> RegistrosInvalidos { get; set; }
        public string Excecao { get; set; }
        public string MensagemStaus { get; set; }
        public bool FileReplace { get; set; }

        public string Path { get; set; }
    }
}
