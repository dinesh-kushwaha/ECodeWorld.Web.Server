using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Cities
    {
        public Cities()
        {
            CitiesMl = new HashSet<CitiesMl>();
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public int? StatesId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public States States { get; set; }
        public ICollection<CitiesMl> CitiesMl { get; set; }
        public ICollection<ZipCodes> ZipCodes { get; set; }
    }
}
