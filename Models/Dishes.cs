#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace CRUDicious.Models;
public class Dish
{
    [Key] // Primary key, DO NOT TOUCH!
    public int DishID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Chef { get; set; }
    [Required]
    [Range(0, 5)]
    public int Tastiness { get; set; }
    [Required]
    [Range(0, 10000)]
    public int Calories { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}