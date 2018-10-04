using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public interface IPostStatusMapper
    {
        IMapper Configuration { get; }
    }
}
