using SchoolNotify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Files.Interfaces
{
    public interface IFileDAO
    {
        string FileUpload(string path, string name, Stream fileStream);
        string FileUpload(string path, FileItem file);
        void Delete(string path, string name);
        void RenameFile(string oldName, string newName, string path);
    }
}
