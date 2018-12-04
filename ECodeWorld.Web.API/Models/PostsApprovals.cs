﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class PostsApprovals
    {
        public PostsApprovals()
        {
            PostsApprovalsMl = new HashSet<PostsApprovalsMl>();
        }

        public int Id { get; set; }
        public int TempPostsId { get; set; }
        public int UsersId { get; set; }
        public string Comments { get; set; }
        public string Messages { get; set; }
        public bool IsDone { get; set; }
        public bool CanPublish { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public TempPosts TempPosts { get; set; }
        public Users Users { get; set; }
        public ICollection<PostsApprovalsMl> PostsApprovalsMl { get; set; }
    }
}
