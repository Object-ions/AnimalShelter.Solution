using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Cat
  {
    public int CatId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Sex { get; set; }
    [Required]
    public int Age { get; set; }
    public string Personality { get; set; }
  }
}