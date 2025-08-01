namespace Server.Models;

public class RecipeStepDTO
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int RecipeId { get; set; }
}