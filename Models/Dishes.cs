#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace LinqEruption.Models;
public class Dish
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Chef { get; set; }
    public int Tastiness { get; set; }
    public int Calories { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Dish(int id, string name, string chef, int tastiness, int calories, DateTime createdAt, DateTime updatedAt)
    {
        ID = id;
        Name = name;
        Chef = chef;
        Tastiness = tastiness;
        Calories = calories;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Type = type;
    }
    
    // This method overrides the original ToString method built into C#
    // So we can get a specialized response!
    public override string ToString()
    {
        return $@"
            Name: {Volcano}
            Year: {Year}
            Location: {Location}
            Elevation: {ElevationInMeters} meters
            Type: {Type}
            ";
    }
}