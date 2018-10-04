using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class States
    {
        public States()
        {
            Cities = new HashSet<Cities>();
            StatesMl = new HashSet<StatesMl>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public DateTime Date { get; set; }
        public int? CountriesId { get; set; }

        public Countries Countries { get; set; }
        public ICollection<Cities> Cities { get; set; }
        public ICollection<StatesMl> StatesMl { get; set; }
    }
}
