using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Accounts
{
    public interface IAccountsMapper
    {
        IMapper Configuration { get; }
    }
}
