using SchoolNotify.Infrastructure.Data.Files.Interfaces;
using SchoolNotify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Files
{
    public class FileDAO : IFileDAO
    {
        public string FileUpload(string path, string name, Stream fileStream)
        {
            var bytes = this.StreamToByteArray(fileStream);
            return this.FileUpload(path, new FileItem { Name = name, FileBytes = bytes });
        }

        public string FileUpload(string path, FileItem file)
        {
            file.FileBytes = string.IsNullOrEmpty(file.FileEncoded) ? file.FileBytes : this.EncodedToByteArray(file.FileEncoded);

            bool exists = Directory.Exists(path);

            DirectoryInfo directoryInfo;

            directoryInfo = !exists ? Directory.CreateDirectory(path) : new DirectoryInfo(path);

            if (file != null)
            {
                string filePath = Path.Combine(directoryInfo.FullName, Path.GetFileName(file.Name));

                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.Write(file.FileBytes, 0, file.FileBytes.Length);
                    imageFile.Flush();
                }
            }

            var name = file.Name;
            file = null;
            return name;
        }

        public void Delete(string path, string name)
        {
            var filePath = (path + "/" + name);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private byte[] EncodedToByteArray(string fileEncoded)
        {
            string base64String = fileEncoded.Split(',')[1];
            return Convert.FromBase64String(base64String);
        }

        private byte[] StreamToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        public void RenameFile(string oldName, string newName, string path)
        {
            System.IO.File.Move(path + "\\" + oldName, path + "\\" + newName);
        }
    }
}
