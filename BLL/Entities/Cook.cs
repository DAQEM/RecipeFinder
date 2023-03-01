namespace BLL.Entities;

public class Cook
{
    private readonly Guid _id;
    private string _userName;
    private string _fullName;
    private string _imageUrl;
    private readonly DateTime _createdAt;
    
    public Cook(Guid id, string userName, string fullName, string imageUrl, DateTime createdAt)
    {
        _id = id;
        _userName = userName;
        _fullName = fullName;
        _imageUrl = imageUrl;
        _createdAt = createdAt;
    }
    
    public Guid Id => _id;
    public string UserName => _userName;
    public string FullName => _fullName;
    public string ImageUrl => _imageUrl;
    public DateTime CreatedAt => _createdAt;
    
    public void UpdateUserName(string userName)
    {
        _userName = userName;
    }
    
    public void UpdateFullName(string fullName)
    {
        _fullName = fullName;
    }
    
    public void UpdateImageUri(string imageUrl)
    {
        _imageUrl = imageUrl;
    }
    
    public class Builder
    {
        private Guid _id = new();
        private string _userName = string.Empty;
        private string _fullName = string.Empty;
        private string _imageUrl = string.Empty;
        private DateTime _createdAt = DateTime.Now;

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

        public Cook Build()
        {
            return new Cook(_id, _userName, _fullName, _imageUrl, _createdAt);
        }
    }
}