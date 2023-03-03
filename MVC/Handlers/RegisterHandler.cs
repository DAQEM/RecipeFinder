using MVC.Models.Auth;

namespace MVC.Handlers;

public static class RegisterHandler
{
    private const string Successful = "Successful";
    
    private const int MinPasswordLength = 8;
    private const int MinUsernameLength = 3;
    private const int MinFullNameLength = 3;
    
    public static List<string> GetErrors(RegisterModel model)
    {
        model.TrimAll();
        
        List<string> errors = new()
        {
            CheckPasswordMatch(model),
            CheckPasswordLength(model),
            CheckUsernameLength(model),
            CheckFullNameLength(model),
            CheckEmailValid(model)
        };

        return errors.Where(error => error != Successful).ToList();
    }

    private static string CheckEmailValid(RegisterModel model)
    {
        return model.Email.Split("@").Length != 2 || model.Email.Split("@")[1].Split(".").Length < 2 ? "Email is not valid." : Successful;
    }

    private static string CheckFullNameLength(RegisterModel model)
    {
        return model.Fullname.Length < MinFullNameLength ? "Full name must be at least 3 characters long." : Successful;
    }

    private static string CheckUsernameLength(RegisterModel model)
    {
        return model.Username.Length < MinUsernameLength ? "Username must be at least 3 characters long." : Successful;
    }

    private static string CheckPasswordLength(RegisterModel model)
    {
        return model.Password.Length < MinPasswordLength ? "Password must be at least 8 characters long." : Successful;
    }

    private static string CheckPasswordMatch(RegisterModel model)
    {
        return model.Password != model.ConfirmPassword ? "Passwords do not match." : Successful;
    }
}