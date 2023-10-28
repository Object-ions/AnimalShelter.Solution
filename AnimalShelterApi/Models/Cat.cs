using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Cat
  {
    public int CatId { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Cat must have a sex")]
    public string Sex { get; set; }
    [Required]
    [Range (0, 240, ErrorMessage = "Age must be between 0 to 240 (months)")]
    public int Age { get; set; }
    public string Personality { get; set; }
  }
}