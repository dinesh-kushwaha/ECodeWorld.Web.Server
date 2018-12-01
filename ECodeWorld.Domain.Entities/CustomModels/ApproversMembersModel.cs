using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Entities.CustomModels
{
    public class ApproversMembersModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string UserAvtar { get; set; }

        public int? ApproverTypesId { get; set; }
        public string ApproverType { get; set; }

        public int? PostCategoryId { get; set; }
        public string PostCategory { get; set; }
        public string PostCategoryIcon { get; set; }
        

    }
}
