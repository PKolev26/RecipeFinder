using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class RecipeMaker
    {
        [Required]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; } = null!;

        [Required]
        public string MakerId { get; set; } = string.Empty;

        [ForeignKey(nameof(MakerId))]
        public IdentityUser Maker { get; set; } = null!;
    }
}
