using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Models
{
    public class FileResponse
    {
        public string Folder { get; set; }
        public string File { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
    }
}
