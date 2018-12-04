using ECodeWorld.Domain.Dtos.Accounts;
using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Dtos.Posts
{
    public class PostsApprovalsDto : DtoBase
    {
        public PostsApprovalsDto()
        {
            PostsApprovalsMl = new HashSet<PostsApprovalsMlDto>();
        }
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
        public UsersDto Users { get; set; }
        public ICollection<PostsApprovalsMlDto> PostsApprovalsMl { get; set; }
    }
}
