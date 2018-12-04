using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class PostsReviewers
    {
        public PostsReviewers()
        {
            PostsReviewersMl = new HashSet<PostsReviewersMl>();
        }

        public int Id { get; set; }
        public int TempPostsId { get; set; }
        public int ApproverTypesId { get; set; }
        public int UsersId { get; set; }
        public string Comments { get; set; }
        public string Messages { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ApproverTypes ApproverTypes { get; set; }
        public TempPosts TempPosts { get; set; }
        public Users Users { get; set; }
        public ICollection<PostsReviewersMl> PostsReviewersMl { get; set; }
    }
}
