using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Maker
    {
        [Key]
        [Comment("Maker Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        //[Range(DifficultySkillLevelMin, DifficultySkillLevelMax)]
        [Comment("The skill level that the cook have")]
        public double SkillLevel { get; set; }
        
        [Comment("Recipe Makers")]
        public ICollection<RecipeMaker> RecipesMakers { get; set; } = new List<RecipeMaker>();
    }
}
