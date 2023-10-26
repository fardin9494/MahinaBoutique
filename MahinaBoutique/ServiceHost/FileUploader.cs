using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public string Upload(IFormFile file, string folder , bool ProductOrArticle)
        {
            if(file == null)
            {
                return "";
            }
            string Basefolder;

            if (ProductOrArticle)
            {
                Basefolder = "ProductPictures";
            }
            else
            {
                Basefolder = "ArticlePictures";
            }


           var DirectoryPath = $"{_webHostEnvironment.WebRootPath}//{Basefolder}//{folder}";

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

           var UniqueFileName = $"{DateTime.Now.ToShortFileName()}.{file.FileName}"; 
           var Fullpath = $"{DirectoryPath}//{UniqueFileName}";
                
           using (var CreatePath = File.Create(Fullpath))
            {
                file.CopyTo(CreatePath);
            }

           return $"{folder}/{UniqueFileName}";
        }
    }
}
