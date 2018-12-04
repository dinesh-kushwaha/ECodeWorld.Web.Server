using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Users
    {
        public Users()
        {
            ApproverTypesUsers = new HashSet<ApproverTypesUsers>();
            Comments = new HashSet<Comments>();
            Logins = new HashSet<Logins>();
            Posts = new HashSet<Posts>();
            PostsApprovals = new HashSet<PostsApprovals>();
            PostsReviewers = new HashSet<PostsReviewers>();
            TempPosts = new HashSet<TempPosts>();
            UsersAddress = new HashSet<UsersAddress>();
            UsersCertifications = new HashSet<UsersCertifications>();
            UsersGroups = new HashSet<UsersGroups>();
            UsersPolicies = new HashSet<UsersPolicies>();
            UsersProfiles = new HashSet<UsersProfiles>();
            UsersQualifications = new HashSet<UsersQualifications>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool? IsWebUser { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<ApproverTypesUsers> ApproverTypesUsers { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Logins> Logins { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<PostsApprovals> PostsApprovals { get; set; }
        public ICollection<PostsReviewers> PostsReviewers { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
        public ICollection<UsersAddress> UsersAddress { get; set; }
        public ICollection<UsersCertifications> UsersCertifications { get; set; }
        public ICollection<UsersGroups> UsersGroups { get; set; }
        public ICollection<UsersPolicies> UsersPolicies { get; set; }
        public ICollection<UsersProfiles> UsersProfiles { get; set; }
        public ICollection<UsersQualifications> UsersQualifications { get; set; }
    }
}
