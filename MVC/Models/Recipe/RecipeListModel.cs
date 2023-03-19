namespace MVC.Models.Recipe;

public class RecipeListModel
{
    public BLL.Entities.Cook.Cook Viewer { get; set; }
    public List<BLL.Entities.Recipe.Recipe> Recipes { get; set; }
}