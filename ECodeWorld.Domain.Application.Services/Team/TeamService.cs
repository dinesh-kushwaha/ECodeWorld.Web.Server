using ECodeWorld.Domain.Application.Services.Core;
using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Application.Services.Team
{
    public class TeamService : ServiceBase, ITeamService
    {
        public IEnumerable<IDto> GetTeamMembers()
        {
            throw new NotImplementedException();
        }
    }
}
