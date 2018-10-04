using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Logins = new HashSet<Logins>();
            Memberships = new HashSet<Memberships>();
            PostReviews = new HashSet<PostReviews>();
            Posts = new HashSet<Posts>();
            TempPosts = new HashSet<TempPosts>();
            UserCertifications = new HashSet<UserCertifications>();
            UserProfiles = new HashSet<UserProfiles>();
            UserQualifications = new HashSet<UserQualifications>();
            UsersAddress = new HashSet<UsersAddress>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Logins> Logins { get; set; }
        public ICollection<Memberships> Memberships { get; set; }
        public ICollection<PostReviews> PostReviews { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
        public ICollection<UserCertifications> UserCertifications { get; set; }
        public ICollection<UserProfiles> UserProfiles { get; set; }
        public ICollection<UserQualifications> UserQualifications { get; set; }
        public ICollection<UsersAddress> UsersAddress { get; set; }
    }
}
