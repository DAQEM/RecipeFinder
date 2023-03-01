namespace MVC.Models.Cook;

public class CookModel
{
    public BLL.Entities.Cook Cook { get; set; } = new BLL.Entities.Cook.Builder().Build();
}