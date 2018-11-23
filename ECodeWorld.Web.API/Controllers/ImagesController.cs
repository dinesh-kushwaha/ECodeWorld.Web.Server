using ECodeWorld.Web.API.DataMapping;
using ECodeWorld.Web.API.Enums;
using ECodeWorld.Web.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Images")]
    [EnableCors("CorsPolicy")]
    //[Consumes("image/jpeg", "image/png", "image/gif")]
    public class ImagesController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public ImagesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        //https://www.c-sharpcorner.com/article/upload-download-files-in-asp-net-core-2-0/
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Json("Files Uploaded");
        }

        [HttpPost("UploadFiles/{documentType}/{newFileName}")]
        public async Task<IActionResult> UploadFiles(IEnumerable<IFormFile> files, DocumentTypesEnum documentType, string newFileName)
        {
            var fileResponse = new List<FileResponse>();
            foreach (var file in files)
            {
                try
                {
                    if (file == null || file.Length == 0)
                        return Content("file not selected");

                    var ext = Path.GetExtension(file.FileName);
                    newFileName = newFileName + ext;

                    if (!GetMimeTypes().ContainsKey(ext))
                        return Content("Invalid file.");

                    //var rnd = new Random();
                    //int preFix = rnd.Next(1, 100);

                    //var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);
                    //var fileName = preFix + fileNameWithoutExt + ext;

                    //string webRootPath = _hostingEnvironment.WebRootPath;
                    //string dateFolder = DateTime.Now.ToString("MM_dd_yyyy");

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    var folder = FolderDataMapping.GetFolder(documentType);

                    string newPath = Path.Combine(webRootPath, folder);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    var path = Path.Combine(newPath, newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        fileResponse.Add(new FileResponse
                        {
                            Name = newFileName,
                            Extension = ext,
                            Folder = folder,
                            File = newFileName
                        });
                    }
                }
                catch (Exception exe)
                {
                    return Content(exe.Message);
                }
            }

            return Json(fileResponse);
        }

        [HttpGet("Download")]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
            };
        }

        [HttpGet("FetchImage/{folder}/{file}")]
        public async Task<string> FetchImage(string folder, string fileName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder, fileName);
            var ext = Path.GetExtension(imagePath);
            var types = GetMimeTypes();
            byte[] imageByteData = await System.IO.File.ReadAllBytesAsync(imagePath);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            return string.Format("data:{0};base64,{1}", types[ext], imageBase64Data);
        }

        //http://localhost:44396/api/Images/ShowImage?folder=static\images\avtars&fileName=2.jpg
        [HttpGet("GetImage/{documentType}/{fileName}")]
        public async Task<string> ShowImage(DocumentTypesEnum documentType, string fileName)
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            var folder = FolderDataMapping.GetFolder(documentType);
            string imagePath = Path.Combine(webRootPath, folder, fileName);
            byte[] imageByteData = await System.IO.File.ReadAllBytesAsync(imagePath);
            string imageBase64Data = Convert.ToBase64String(imageByteData,0, imageByteData.Length);
            string ext = Path.GetExtension(imagePath);
            var mimeTypes = GetMimeTypes();
            return string.Format("data:{0};base64, {1}", mimeTypes[ext], imageBase64Data);
        }
    }
}