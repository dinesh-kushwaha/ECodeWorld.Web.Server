using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
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
            PostsApprovalsMl = new HashSet<PostsApprovalsMl>();
            PostsCategoriesMl = new HashSet<PostsCategoriesMl>();
            PostsMl = new HashSet<PostsMl>();
            PostsReviewersMl = new HashSet<PostsReviewersMl>();
            PostsStatusMl = new HashSet<PostsStatusMl>();
            PostsTypesMl = new HashSet<PostsTypesMl>();
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
        public ICollection<PostsApprovalsMl> PostsApprovalsMl { get; set; }
        public ICollection<PostsCategoriesMl> PostsCategoriesMl { get; set; }
        public ICollection<PostsMl> PostsMl { get; set; }
        public ICollection<PostsReviewersMl> PostsReviewersMl { get; set; }
        public ICollection<PostsStatusMl> PostsStatusMl { get; set; }
        public ICollection<PostsTypesMl> PostsTypesMl { get; set; }
        public ICollection<StatesMl> StatesMl { get; set; }
        public ICollection<TempPostsMl> TempPostsMl { get; set; }
    }
}
