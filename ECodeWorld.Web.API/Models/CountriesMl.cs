using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class CountriesMl
    {
        public int Id { get; set; }
        public int? CountriesId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Countries Countries { get; set; }
        public Languages Language { get; set; }
    }
}
