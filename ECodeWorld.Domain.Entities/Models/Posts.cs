using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            LikesCounters = new HashSet<LikesCounters>();
            PostsImages = new HashSet<PostsImages>();
            PostsMl = new HashSet<PostsMl>();
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
        public PostCategories Category { get; set; }
        public ComplexityLevels ComplexityLevels { get; set; }
        public PostStatus PostStatus { get; set; }
        public PostTypes PostTypes { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<LikesCounters> LikesCounters { get; set; }
        public ICollection<PostsImages> PostsImages { get; set; }
        public ICollection<PostsMl> PostsMl { get; set; }
    }
}
