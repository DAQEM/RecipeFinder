namespace BLL.Entities.Recipe;

public class Saver
{
    private readonly string _fullname;
    private readonly string _username;
    private readonly string _imageUrl;

    public Saver(string fullname, string username, string imageUrl)
    {
        _fullname = fullname;
        _username = username;
        _imageUrl = imageUrl;
    }

    public string Fullname => _fullname;
    public string Username => _username;
    public string ImageUrl => _imageUrl;
}