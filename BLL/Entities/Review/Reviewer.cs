using BLL.Exceptions;

namespace BLL.Entities.Review;

public class Reviewer
{
    private string _fullname;
    private string _username;
    private string _imageUrl;

    public Reviewer(string fullname, string username, string imageUrl)
    {
        _fullname = fullname;
        _username = username;
        _imageUrl = imageUrl;
    }

    public string Fullname { get => _fullname; set => _fullname = value; }
    public string Username { get => _username; set => _username = value; }
    public string ImageUrl { get => _imageUrl; set => _imageUrl = value; }
    
    public static Reviewer Empty => new(string.Empty, string.Empty, string.Empty);
    
    public class Builder
    {
        private Reviewer _reviewer = Empty;

        public Builder FromCook(Cook.Cook cook)
        {
            _reviewer = new(cook.Fullname, cook.Username, cook.ImageUrl);
            return this;
        }
        
        public Builder WithFullname(string fullname)
        {
            _reviewer.Fullname = fullname;
            return this;
        }

        public Builder WithUsername(string username)
        {
            _reviewer.Username = username;
            return this;
        }

        public Builder WithImageUrl(string imageUrl)
        {
            _reviewer.ImageUrl = imageUrl;
            return this;
        }

        public Reviewer Build()
        {
            if (_reviewer.Fullname == null || _reviewer.Username == null || _reviewer.ImageUrl == null)
            {
                throw new IncompleteBuilderException(typeof(Reviewer));
            }
            return _reviewer;
        }
    }
}