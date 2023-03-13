namespace BLL.Entities.Review;

public class Reviewer
{
    private readonly string _fullname;
    private readonly string _username;
    private readonly string _imageUrl;

    public Reviewer(string fullname, string username, string imageUrl)
    {
        _fullname = fullname;
        _username = username;
        _imageUrl = imageUrl;
    }

    public static Reviewer Empty => new(string.Empty, string.Empty, string.Empty);
    public string Fullname => _fullname;
    public string Username => _username;
    public string ImageUrl => _imageUrl;
}