using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class Languages
    {
        public Languages()
        {
            ApproverTypessMl = new HashSet<ApproverTypessMl>();
            CitiesMl = new HashSet<CitiesMl>();
            CommentsMl = new HashSet<CommentsMl>();
            ComplexityLevelsMl = new HashSet<ComplexityLevelsMl>();
            CountriesMl = new HashSet<CountriesMl>();
            PostCategoriesMl = new HashSet<PostCategoriesMl>();
            PostStatusMl = new HashSet<PostStatusMl>();
            PostTypesMl = new HashSet<PostTypesMl>();
            PostsApprovalsMl = new HashSet<PostsApprovalsMl>();
            PostsMl = new HashSet<PostsMl>();
            PostsReviewersMl = new HashSet<PostsReviewersMl>();
            StatesMl = new HashSet<StatesMl>();
            TempPostsMl = new HashSet<TempPostsMl>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NameLocal { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<ApproverTypessMl> ApproverTypessMl { get; set; }
        public ICollection<CitiesMl> CitiesMl { get; set; }
        public ICollection<CommentsMl> CommentsMl { get; set; }
        public ICollection<ComplexityLevelsMl> ComplexityLevelsMl { get; set; }
        public ICollection<CountriesMl> CountriesMl { get; set; }
        public ICollection<PostCategoriesMl> PostCategoriesMl { get; set; }
        public ICollection<PostStatusMl> PostStatusMl { get; set; }
        public ICollection<PostTypesMl> PostTypesMl { get; set; }
        public ICollection<PostsApprovalsMl> PostsApprovalsMl { get; set; }
        public ICollection<PostsMl> PostsMl { get; set; }
        public ICollection<PostsReviewersMl> PostsReviewersMl { get; set; }
        public ICollection<StatesMl> StatesMl { get; set; }
        public ICollection<TempPostsMl> TempPostsMl { get; set; }
    }
}
