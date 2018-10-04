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
    [Route("api/PdfDocZipUpload")]
    [EnableCors("CorsPolicy")]
    //[Consumes("image/*")]
    public class PdfDocZipUploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public PdfDocZipUploadController(IHostingEnvironment hostingEnvironment)
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

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles(IEnumerable<IFormFile> files)
        {
            var fileResponse = new List<FileResponse>();
            foreach (var file in files)
            {
                try
                {
                    if (file == null || file.Length == 0)
                        return Content("file not selected");

                    var ext = Path.GetExtension(file.FileName);

                    if (!GetMimeTypes().ContainsKey(ext))
                        return Content("Invalid file.");

                    var rnd = new Random();
                    int preFix = rnd.Next(1, 100);

                   
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);
                    var fileName = preFix + fileNameWithoutExt + ext;

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string dateFolder = DateTime.Now.ToString("MM_dd_yyyy");

                    string newPath = Path.Combine(webRootPath, "static", "images", dateFolder);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    var path = Path.Combine(newPath, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        fileResponse.Add(new FileResponse
                        {
                            Name = fileName,
                            Extension = ext,
                            Folder = dateFolder,
                            File = fileName
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

        [HttpGet]
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

            //var fileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();
            //string contentType = ""; fileExtensionContentTypeProvider.TryGetContentType(path, out contentType);
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
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".csv", "text/csv"}
            };
        }
    }
}