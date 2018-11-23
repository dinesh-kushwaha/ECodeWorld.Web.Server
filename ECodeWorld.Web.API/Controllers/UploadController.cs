﻿using ECodeWorld.Web.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Upload")]
    [EnableCors("CorsPolicy")]
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //[HttpPost("UploadFiles"), DisableRequestSizeLimit]
        //public async Task<IActionResult> Post(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);
        //    // full path to file in temp location
        //    var filePath = Path.GetTempFileName();
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    // process uploaded files
        //    // Don't rely on or trust the FileName property without validation.
        //    return Ok(new { count = files.Count, size, filePath });
        //}

        //[HttpPost, DisableRequestSizeLimit]
        //public ActionResult UploadFile()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        string folderName = "Upload";
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        string newPath = Path.Combine(webRootPath, folderName);
        //        if (!Directory.Exists(newPath))
        //        {
        //            Directory.CreateDirectory(newPath);
        //        }
        //        if (file.Length > 0)
        //        {
        //            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            string fullPath = Path.Combine(newPath, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }
        //        return Json("Upload Successful.");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return Json("Upload Failed: " + ex.Message);
        //    }
        //}

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile()
        {
            try
            {
                //var file = Request.Form.Files[0];
                var fileResponse = new List<FileResponse>();
                string folderName = "avtars";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, "static", "images", folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (var file in Request.Form.Files)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                        fileResponse.Add(new FileResponse
                        {
                            Name = fileName,
                            Extension = ext,
                            Folder = folderName,
                            File = fileName,
                            Message = "Upload Successful"
                        });
                    }
                }
                return Json(fileResponse);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
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


        [HttpGet]
        public async Task<string> GetImage(string relativePath)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
            var ext = Path.GetExtension(imagePath);
            var types = GetMimeTypes();
            byte[] imageByteData = await System.IO.File.ReadAllBytesAsync(imagePath);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            return string.Format("data:{0};base64,{1}", types[ext], imageBase64Data);
        }
    }
}
