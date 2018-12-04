using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class ZipCodes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public int? CitiesId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Cities Cities { get; set; }
    }
}
