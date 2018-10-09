using ECodeWorld.Domain.Dtos.Users;

namespace ECodeWorld.Domain.Dtos.Posts
{
    public class TempPostsDto : PostsDtoBase
    {
        public AuthorDto Author { get; set; }
    }
}
