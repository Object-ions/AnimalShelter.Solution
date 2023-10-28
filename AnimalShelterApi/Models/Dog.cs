using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Sex { get; set; }
    [Required]
    public int Age { get; set; }
  }
}