using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Languages
    {
        public Languages()
        {
            CitiesMl = new HashSet<CitiesMl>();
            CommentsMl = new HashSet<CommentsMl>();
            ComplexityLevelsMl = new HashSet<ComplexityLevelsMl>();
            CountriesMl = new HashSet<CountriesMl>();
            PostCategoriesMl = new HashSet<PostCategoriesMl>();
            PostReviewsMl = new HashSet<PostReviewsMl>();
            PostStatusMl = new HashSet<PostStatusMl>();
            PostTypesMl = new HashSet<PostTypesMl>();
            PostsMl = new HashSet<PostsMl>();
            StatesMl = new HashSet<StatesMl>();
            TempPostsMl = new HashSet<TempPostsMl>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NameLocal { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public ICollection<CitiesMl> CitiesMl { get; set; }
        public ICollection<CommentsMl> CommentsMl { get; set; }
        public ICollection<ComplexityLevelsMl> ComplexityLevelsMl { get; set; }
        public ICollection<CountriesMl> CountriesMl { get; set; }
        public ICollection<PostCategoriesMl> PostCategoriesMl { get; set; }
        public ICollection<PostReviewsMl> PostReviewsMl { get; set; }
        public ICollection<PostStatusMl> PostStatusMl { get; set; }
        public ICollection<PostTypesMl> PostTypesMl { get; set; }
        public ICollection<PostsMl> PostsMl { get; set; }
        public ICollection<StatesMl> StatesMl { get; set; }
        public ICollection<TempPostsMl> TempPostsMl { get; set; }
    }
}
