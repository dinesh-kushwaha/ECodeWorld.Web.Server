using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;
namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostsComplexityService
    {
        Task<ComplexityLevelsDto> GetPostComplexityLevel(int complexityLevelId);
        Task<IEnumerable<ComplexityLevelsDto>> GetComplexityLevels(SearchCriteriaDto searchCriteriaDto);
    }
}
