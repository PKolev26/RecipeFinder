using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.DifficultyModels
{
    public class DifficultyViewModel
    {
        [Display(Name = "Difficulty Id")]
        public int Id { get; set; }

        [Display(Name = "Difficulty Name")]
        public string Name { get; set; } = null!;
    }
}
