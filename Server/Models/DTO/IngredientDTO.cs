namespace Server.Models.DTO;

public class IngredientDTO
{
    public int Id { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }
    public int MeasurementId { get; set; }
    public int RecipeId { get; set; }
}