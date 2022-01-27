using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Registration_Login_Identity.IUnitOfWorkFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.ServiceImage
{
    public class UnitOfWorkService : IUnitOfWork
    {
      
        private IHostingEnvironment _hostingEnvironment;
    public UnitOfWorkService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async void uploadImage(IFormFile file)
        {
            long totalBytes = file.Length;
            string fileName = file.FileName.Trim('"');
            fileName = EnsureFileName(fileName);
            byte[] buffer = new byte[16 * 1024];
            using (FileStream output = File.Create(GetPathAndFileName(fileName)))
            {
                using(Stream input = file.OpenReadStream())
                {
                    int readBytes;
                    while((readBytes = input.Read(buffer,0,buffer.Length))>0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }
        }

        private string GetPathAndFileName(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath + "\\UploadsImages\\";
            if (!Directory.Exists(path))
            
                Directory.CreateDirectory(path);
                return path + fileName;
            
        }

        private string EnsureFileName(string fileName)
        {
            if (fileName.Contains("\\"))
            
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                return fileName;
            
        }

    }
}
