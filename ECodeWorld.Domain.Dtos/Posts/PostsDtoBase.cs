using ECodeWorld.Domain.Dtos.Core;
using System;

namespace ECodeWorld.Domain.Dtos.Posts
{
    public abstract class PostsDtoBase : DtoBase, IPostDto
    {
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
        public DateTime Date { get; set; }
        public int? PostStatusId { get; set; }
    }
}
