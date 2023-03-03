namespace MVC.Models.Auth;

public class RegisterModel
{
    public string Username { get; set; } = string.Empty;
    public string Fullname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public void TrimAll()
    {
        Username = Username == null ? string.Empty : Username.Trim();
        Fullname = Fullname == null ? string.Empty : Fullname.Trim();
        Email = Email == null ? string.Empty : Email.Trim();
        Password = Password == null ? string.Empty : Password.Trim();
        ConfirmPassword = ConfirmPassword == null ? string.Empty : ConfirmPassword.Trim();
    }
}