namespace Server.Models;

public class RecipeStep
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int RecipeId { get; set; }
    public virtual Recipe Recipe { get; set; }
}