using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Usres
{
    public interface IAuthMapper
    {
        IMapper Configuration { get; }
    }
}
