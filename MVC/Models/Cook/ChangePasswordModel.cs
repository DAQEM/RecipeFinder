﻿namespace MVC.Models.Cook;

public class ChangePasswordModel
{
    public string Username { get; set; } = string.Empty;
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmNewPassword { get; set; } = string.Empty;
    
    public void TrimAll()
    {
        Username = Username.Trim();
        OldPassword = OldPassword.Trim();
        NewPassword = NewPassword.Trim();
        ConfirmNewPassword = ConfirmNewPassword.Trim();
    }
}