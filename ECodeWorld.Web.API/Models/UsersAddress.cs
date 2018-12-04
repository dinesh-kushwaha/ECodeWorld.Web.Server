using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class UsersAddress
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? PostalCode { get; set; }
        public int? UsersId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Users Users { get; set; }
    }
}
