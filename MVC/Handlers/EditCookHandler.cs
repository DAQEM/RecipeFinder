using MVC.Models.Auth;
using MVC.Models.Cook;

namespace MVC.Handlers;

public class EditCookHandler
{
    private const string Successful = "Successful";
    
    private const int MinFullNameLength = 3;
    
    public static List<string> GetErrors(EditCookModel model)
    {
        model.TrimAll();
        
        List<string> errors = new()
        {
            CheckFullNameLength(model),
            CheckEmailValid(model),
            CheckImageUrlValid(model)
        };

        return errors.Where(error => error != Successful).ToList();
    }

    private static string CheckEmailValid(EditCookModel model)
    {
        return model.Email.Split("@").Length != 2 || model.Email.Split("@")[1].Split(".").Length < 2 ? "Email is not valid." : Successful;
    }

    private static string CheckFullNameLength(EditCookModel model)
    {
        return model.Fullname.Length < MinFullNameLength ? "Full name must be at least 3 characters long." : Successful;
    }
    
    private static string CheckImageUrlValid(EditCookModel model)
    {
        return !UriHandler.IsValidUri(model.ImageUrl) ? "Profile picture URL must be a valid URL. (don't forget http:// or https://)" : Successful;
    }
}