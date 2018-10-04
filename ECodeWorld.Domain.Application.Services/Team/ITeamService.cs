using ECodeWorld.Domain.Dtos.Core;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Application.Services.Team
{
    public interface ITeamService
    {
        IEnumerable<IDto> GetTeamMembers();
    }
}
