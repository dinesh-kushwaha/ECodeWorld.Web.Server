using ECodeWorld.Domain.Entities.CustomModels;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories.SearchCriteriaModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public class ApproversRepository : IApproversRepository, IDisposable
    {

        private readonly ECodeWorldContext eCodeWorldContext;
        public ApproversRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public ApproversRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }
        public async Task<IEnumerable<ApproverTypes>> GetApprovers(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.ApproverTypes.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                try
                {
                    return await eCodeWorldContext.ApproverTypes.
                           Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                           Take(searchCriteria.PageSize).ToListAsync();
                }
                catch (Exception exe)
                {
                    return null;
                }
            }
        }

        public async Task<ApproverTypes> GetApprover(int approverTypeId)
        {
            return await eCodeWorldContext.ApproverTypes.FirstOrDefaultAsync(p => p.Id == approverTypeId);
        }

        public async Task<IEnumerable<ApproversMembersModel>> GetApproversMembers(ApproversMembersSC searchCriteria)
        {
            if (searchCriteria == null)
                return null;

            var sqlQuery = (from u in eCodeWorldContext.Users
                            join up in eCodeWorldContext.UsersProfiles on u.Id equals up.UsersId 
                            join aptu in eCodeWorldContext.ApproverTypesUsers on u.Id equals aptu.UsersId
                            join apt in eCodeWorldContext.ApproverTypes on aptu.ApproverTypesId equals apt.Id into apttu
                            from apt in apttu.DefaultIfEmpty()
                            join pc in eCodeWorldContext.PostCategories on aptu.PostCategoriesId equals pc.Id into aptupc
                            from pc in aptupc.DefaultIfEmpty()
                            select new ApproversMembersModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                DisplayName = u.DisplayName,
                                UserAvtar = up.Avtar,
                                ApproverTypesId = apttu != null ? pc.Id : default(int),
                                ApproverType = apttu != null ? apt.Name : default(string),
                                PostCategoryId = apttu != null ? pc.Id : default(int),
                                PostCategory = aptupc != null ? pc.Category : default(string),
                                PostCategoryIcon = aptupc != null ? pc.Icon : default(string),
                            });
            try
            {

                if (searchCriteria.IsOrderByDescending)
                {
                    return await sqlQuery.
                           OrderByDescending(p => p.Id).
                           Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                           Take(searchCriteria.PageSize).ToListAsync();
                }
                else
                {
                    return await sqlQuery.
                           Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                           Take(searchCriteria.PageSize).ToListAsync();
                }
            }
            catch (Exception exe)
            {

                return null;
            }
        }

        public void Dispose()
        {
            if (eCodeWorldContext != null)
                eCodeWorldContext.Dispose();
        }
    }
}
