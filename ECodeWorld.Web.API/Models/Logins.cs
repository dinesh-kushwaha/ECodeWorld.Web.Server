﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class Logins
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public int? UsersId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Users Users { get; set; }
    }
}