using ECodeWorld.Domain.Dtos.Core;
using ECodeWorld.Domain.Dtos.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Authentication
{
    public class AuthenticationDto : ResponseDto
    {
        public bool IsAuthenticated { get; set; }
    }
}
