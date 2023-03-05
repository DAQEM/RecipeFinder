using MVC.Models.Cook;

namespace MVC.Handlers;

public static class ChangePasswordHandler
{
    private const string Successful = "Successful";
    
    private const int MinPasswordLength = 8;
    
    public static List<string> GetErrors(ChangePasswordModel model)
    {
        model.TrimAll();
        
        List<string> errors = new()
        {
            CheckPasswordMatch(model),
            CheckPasswordLength(model),
        };

        return errors.Where(error => error != Successful).ToList();
    }

    private static string CheckPasswordLength(ChangePasswordModel model)
    {
        return model.NewPassword.Length < MinPasswordLength ? "Password must be at least 8 characters long." : Successful;
    }

    private static string CheckPasswordMatch(ChangePasswordModel model)
    {
        return model.NewPassword != model.ConfirmNewPassword ? "Passwords do not match." : Successful;
    }
}