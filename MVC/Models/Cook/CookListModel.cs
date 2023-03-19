namespace MVC.Models.Cook;

public class CookListModel
{
    public BLL.Entities.Cook.Cook? Viewer { get; set; }
    public List<BLL.Entities.Cook.Cook> Cooks { get; set; }
}