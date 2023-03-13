namespace BLL.Entities.Cook;

public class Follower
{
    private readonly string _fullname;
    private readonly string _username;
    private readonly string _imageUrl;

    public Follower(string fullname, string username, string imageUrl)
    {
        _fullname = fullname;
        _username = username;
        _imageUrl = imageUrl;
    }

    public string Fullname => _fullname;
    public string Username => _username;
    public string ImageUrl => _imageUrl;
}