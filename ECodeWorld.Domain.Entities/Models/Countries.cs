using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Countries
    {
        public Countries()
        {
            CountriesMl = new HashSet<CountriesMl>();
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public DateTime Date { get; set; }

        public ICollection<CountriesMl> CountriesMl { get; set; }
        public ICollection<States> States { get; set; }
    }
}
