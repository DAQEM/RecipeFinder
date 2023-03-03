using BLL.Entities.Review;

namespace BLL.Entities.Cook;

public class Cook
{
    private readonly Guid _id;
    private string _username;
    private string _fullname;
    private string _imageUrl;
    private readonly DateTime _createdAt;
    private readonly Credential _credential;
    
    private List<CookReview> _cookReviews;
    
    private Cook(Guid id, string username, string fullname, string imageUrl, DateTime createdAt, List<CookReview> cookReviews, Credential credential)
    {
        _id = id;
        _username = username;
        _fullname = fullname;
        _imageUrl = imageUrl;
        _createdAt = createdAt;
        _cookReviews = cookReviews;
        _credential = credential;
    }
    
    public Guid Id => _id;
    public string Username => _username;
    public string Fullname => _fullname;
    public string ImageUrl => _imageUrl;
    public DateTime CreatedAt => _createdAt;
    public Credential Credential => _credential;
    
    public void UpdateUserName(string userName)
    {
        _username = userName;
    }
    
    public void UpdateFullName(string fullName)
    {
        _fullname = fullName;
    }
    
    public void UpdateImageUri(string imageUrl)
    {
        _imageUrl = imageUrl;
    }

    public class Builder
    {
        private Guid _id;
        private string _userName = string.Empty;
        private string _fullName = string.Empty;
        private string _imageUrl = string.Empty;
        private DateTime _createdAt = DateTime.Now;
        private Credential _credential = new(string.Empty, string.Empty, DateTime.Now);
        
        private List<CookReview> _cookReviews = new();

        public Builder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public Builder WithUserName(string userName)
        {
            _userName = userName;
            return this;
        }

        public Builder WithFullName(string fullName)
        {
            _fullName = fullName;
            return this;
        }

        public Builder WithImageUri(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }

        public Builder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public Builder WithCookReviews(List<CookReview> cookReviews)
        {
            _cookReviews = cookReviews;
            return this;
        }
        
        public Builder WithCredential(Credential credential)
        {
            _credential = credential;
            return this;
        }

        public Cook Build()
        {
            return new Cook(_id, _userName, _fullName, _imageUrl, _createdAt, _cookReviews, _credential);
        }
    }
}