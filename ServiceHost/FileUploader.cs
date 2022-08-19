using _0_FrameWork.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = new StringBuilder();
            directoryPath.Append(_webHostEnvironment.WebRootPath);
            directoryPath.Append("/ProductPictures/");
            directoryPath.Append(path);
            directoryPath.Append('\x200E');

            //var directoryPath = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";

            if (!Directory.Exists(directoryPath.ToString()))
                Directory.CreateDirectory(directoryPath.ToString());

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            directoryPath.Append(fileName);

            //var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(directoryPath.ToString());
            file.CopyTo(output);
            var result=new StringBuilder();
            result.Append(path);
            result.Append('\x200E');
            result.Append(fileName);
            return result.ToString();
        }

    }
}
