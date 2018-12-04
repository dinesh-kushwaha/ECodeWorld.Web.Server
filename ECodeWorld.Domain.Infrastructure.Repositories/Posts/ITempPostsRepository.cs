using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.Models;
namespace ECodeWorld.Domain.Infrastructure.Repositories.Posts
{
    public interface ITempPostsRepository
    {
        Task<PostsApprovals> GetPostsApprovals(int postsApprovalsId);
        Task<PostsReviewers> GetPostsReviewer(int postsReviewersId);
        Task<int> Assign(PostsReviewers postsReviewers);
        Task<int> Approve(PostsApprovals postsApprovals);
    }
}
