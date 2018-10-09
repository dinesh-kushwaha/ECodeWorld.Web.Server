using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;


namespace ECodeWorld.Domain.Infrastructure.Repositories.Posts
{
    public class PostsRepository : IPostsRepository
    {
        private readonly M.ECodeWorldContext eCodeWorldContext;
        public PostsRepository()
        {
            eCodeWorldContext = new M.ECodeWorldContext();
        }
        public PostsRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new M.ECodeWorldContext(connectionString, cacheTimespan);
        }

        public async Task<int> CreatePost(M.Posts posts)
        {
            eCodeWorldContext.Posts.Add(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }
        public async Task<int> UpdatePost(int postId, M.Posts posts)
        {
            var _posts = await eCodeWorldContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (_posts == null)
                return 0;
            posts.Id = postId;
            eCodeWorldContext.Update(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> DeletePost(int postId)
        {
            var posts = await eCodeWorldContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (posts == null)
                return 0;
            eCodeWorldContext.Remove(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<M.Posts>> GetMostViewdPosts(SearchCriteria searchCriteria)
        {
            return await eCodeWorldContext.Posts.OrderByDescending(p => p.Id).
                Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).ToListAsync();
        }

        public async Task<M.Posts> GetPost(int postId)
        {
            return await eCodeWorldContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public Task<M.Posts> GetPostByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<M.Posts>> GetUserPosts(SearchCriteria searchCriteria, int userId)
        {
            if (searchCriteria.PageSize == 0)
            {
                return await eCodeWorldContext.Posts.
                    OrderByDescending(p => p.AuthorId == userId).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.Posts.
                    OrderByDescending(p => p.AuthorId == userId).
                    Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).ToListAsync();
            }
        }
        public async Task<IEnumerable<M.Posts>> GetPosts(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.Posts.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.Posts.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }

        public async Task<IEnumerable<M.Posts>> GetRecentPosts(SearchCriteria searchCriteria)
        {
            return await eCodeWorldContext.Posts.OrderByDescending(p => p.Id).
                 Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<M.Posts>> GetTopPosts(SearchCriteria searchCriteria)
        {
            return await eCodeWorldContext.Posts.OrderByDescending(p => p.Id).
                Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).ToListAsync();
        }

        public async Task<int> CreateTempPost(M.TempPosts posts)
        {
            eCodeWorldContext.TempPosts.Add(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> UpdateTempPost(int postId, M.TempPosts posts)
        {
            var _posts = await eCodeWorldContext.TempPosts.FirstOrDefaultAsync(p => p.Id == postId);
            if (_posts == null)
                return 0;
            posts.Id = postId;
            eCodeWorldContext.Update(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> DeleteTempPost(int postId)
        {
            var posts = await eCodeWorldContext.TempPosts.FirstOrDefaultAsync(p => p.Id == postId);
            if (posts == null)
                return 0;
            eCodeWorldContext.Remove(posts);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<M.TempPosts> GetTempPost(int postId)
        {
            return await eCodeWorldContext.TempPosts.Include(x=>x.Author).FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<IEnumerable<M.TempPosts>> UserPostsLightWeight(SearchCriteria searchCriteria, int userId)
        {
            if (searchCriteria.PageSize == 0)
            {
                return await eCodeWorldContext.TempPosts.
                    OrderByDescending(p => p.AuthorId == userId).
                    Select(x => new M.TempPosts
                    {
                        Id = x.Id,
                        Title = x.Title,
                        PostUrl=x.PostUrl,
                        Description = x.Description,
                        Date = x.Date
                    }).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.TempPosts.
                    OrderByDescending(p => p.AuthorId == userId).
                    Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).
                     Select(x => new M.TempPosts
                     {
                         Id = x.Id,
                         Title = x.Title,
                         PostUrl = x.PostUrl,
                         Description = x.Description,
                         Date = x.Date
                     }).ToListAsync();

            }

        }
        public async Task<IEnumerable<M.TempPosts>> GetTempPosts(SearchCriteria searchCriteria, int userId)
        {
            if (searchCriteria.PageSize == 0)
            {
                return await eCodeWorldContext.TempPosts.
                    OrderByDescending(p => p.AuthorId == userId).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.TempPosts.
                    OrderByDescending(p => p.AuthorId == userId).
                    Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                    Take(searchCriteria.PageSize).ToListAsync();
            }

        }
    }
}
