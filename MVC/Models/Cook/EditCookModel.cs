namespace MVC.Models.Cook;

public class EditCookModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
    public string ImageUrl { get; set; }
    
    public static EditCookModel FromCook(BLL.Entities.Cook.Cook cook)
    {
        return new EditCookModel
        {
            Username = cook.Username,
            Email = cook.Credential.Email,
            Fullname = cook.Fullname,
            ImageUrl = cook.ImageUrl
        };
    }
}