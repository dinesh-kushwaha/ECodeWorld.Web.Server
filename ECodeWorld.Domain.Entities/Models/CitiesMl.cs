using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class CitiesMl
    {
        public int Id { get; set; }
        public int? CitiesId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Cities Cities { get; set; }
        public Languages Language { get; set; }
    }
}
