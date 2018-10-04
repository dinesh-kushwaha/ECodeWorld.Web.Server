using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ComplexityLevelsMl
    {
        public int Id { get; set; }
        public int? ComplexityLevelsId { get; set; }
        public int? LanguageId { get; set; }
        public string Complexity { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public ComplexityLevels ComplexityLevels { get; set; }
        public Languages Language { get; set; }
    }
}
