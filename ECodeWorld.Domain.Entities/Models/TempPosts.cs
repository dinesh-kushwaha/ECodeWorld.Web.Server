using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class TempPosts
    {
        public TempPosts()
        {
            PostsApprovals = new HashSet<PostsApprovals>();
            PostsReviewers = new HashSet<PostsReviewers>();
            TempPostsMl = new HashSet<TempPostsMl>();
        }

        public int Id { get; set; }
        public int? PostTypesId { get; set; }
        public string Title { get; set; }
        public string PostUrl { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public int? ComplexityLevelsId { get; set; }
        public string Keywords { get; set; }
        public int? CategoryId { get; set; }
        public string Contents { get; set; }
        public int Status { get; set; }
        public int LikeCounts { get; set; }
        public int CommentCounts { get; set; }
        public int? PostStatusId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Users Author { get; set; }
        public PostsCategories Category { get; set; }
        public ComplexityLevels ComplexityLevels { get; set; }
        public PostsStatus PostStatus { get; set; }
        public PostsTypes PostTypes { get; set; }
        public ICollection<PostsApprovals> PostsApprovals { get; set; }
        public ICollection<PostsReviewers> PostsReviewers { get; set; }
        public ICollection<TempPostsMl> TempPostsMl { get; set; }
    }
}
