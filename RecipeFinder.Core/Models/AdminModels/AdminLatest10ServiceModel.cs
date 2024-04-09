using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.AdminModels
{
    public class AdminLatest10ServiceModel
    {
        public string CookFirstName { get; set; } = null!;
        public string CookLastName { get; set; } = null!;
        public string Recipe { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string DifficultyName { get; set; } = null!;
        public DateTime PostedOn { get; set; }
        public int CommentsCount { get; set; }
        public bool IsFinished { get; set; }
    }
}
