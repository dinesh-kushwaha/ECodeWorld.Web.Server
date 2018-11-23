using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Posts
{
    public class PostReviewersDto : DtoBase
    {
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
    }
}
