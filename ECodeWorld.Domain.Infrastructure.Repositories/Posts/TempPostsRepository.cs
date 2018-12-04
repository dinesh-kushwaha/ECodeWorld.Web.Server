using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Posts
{
    public class TempPostsRepository : ITempPostsRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;
        public TempPostsRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }

        public async Task<int> Approve(PostsApprovals postsApprovals)
        {
            if (postsApprovals == null)
                return 0;

            var _postsApprovals = await eCodeWorldContext.PostsApprovals.FirstOrDefaultAsync(p => p.Id == postsApprovals.Id);
            if (_postsApprovals == null)
            {
                await eCodeWorldContext.PostsApprovals.AddAsync(postsApprovals);
                return postsApprovals.Id;
            }

            else
            {
                _postsApprovals.Comments = postsApprovals.Comments;
                _postsApprovals.Messages = postsApprovals.Messages;
                _postsApprovals.IsDone = postsApprovals.IsDone;
                _postsApprovals.CanPublish = postsApprovals.CanPublish;
                eCodeWorldContext.PostsApprovals.Update(_postsApprovals);
            }
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> Assign(PostsReviewers postsReviewers)
        {
            if (postsReviewers == null)
                return 0;

            var _postsReviewers = await eCodeWorldContext.PostsReviewers.FirstOrDefaultAsync(p => p.Id == postsReviewers.Id);
            if (_postsReviewers == null)
            {
                await eCodeWorldContext.PostsReviewers.AddAsync(postsReviewers);
                return postsReviewers.Id;
            }

            else
            {
                _postsReviewers.Comments = postsReviewers.Comments;
                _postsReviewers.Messages = postsReviewers.Messages;
                _postsReviewers.ApproverTypesId = postsReviewers.ApproverTypesId;
                _postsReviewers.UsersId = postsReviewers.UsersId;
                _postsReviewers.AssignedDate =DateTime.Now;

                eCodeWorldContext.PostsReviewers.Update(_postsReviewers);
            }
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<PostsApprovals> GetPostsApprovals(int postsApprovalsId)
        {
            return await eCodeWorldContext.PostsApprovals.FirstOrDefaultAsync(x => x.Id == postsApprovalsId);
        }

        public async Task<PostsReviewers> GetPostsReviewer(int postsReviewersId)
        {
            return await eCodeWorldContext.PostsReviewers.FirstOrDefaultAsync(x => x.Id == postsReviewersId);
        }
    }
}
