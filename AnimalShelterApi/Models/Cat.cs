using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Cat
  {
    public int CatId { get; set; }
    [Required (ErrorMessage = "Cat must have a name")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Cat must have a sex")]
    public string Sex { get; set; }
    [Required]
    [Rage (0, 240, ErrorMessage = "Age must be between 0 to 240 (months)")]
    public int Age { get; set; }
    public string Personality { get; set; }
  }
}