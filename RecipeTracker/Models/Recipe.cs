using System.ComponentModel.DataAnnotations;

public class Recipe
{
  public int Id { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required] 
  public string? Ingredients { get; set; } // Can store as a comme-separated string for simplicity

  [Required]
  public string? Instructions { get; set; }

  [DataType(DataType.Date)]
  public DateTime DateCreated { get; set; }

}