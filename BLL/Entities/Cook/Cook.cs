using BLL.Entities.Review;

namespace BLL.Entities.Cook;

public class Cook
{
    private readonly Guid _id;
    private readonly string _username;
    private readonly string _fullname;
    private readonly string _imageUrl;
    private readonly DateTime _createdAt;
    private readonly Credential _credential;

    private readonly Recipe.Recipe[] _recipes;
    private readonly CookReview[] _reviews;
    private readonly Follower[] _followers;

    private Cook(Guid id, string username, string fullname, string imageUrl, 
        DateTime createdAt, Credential credential, Recipe.Recipe[] recipes, 
        CookReview[] reviews, Follower[] followers)
    {
        _id = id;
        _username = username;
        _fullname = fullname;
        _imageUrl = imageUrl;
        _createdAt = createdAt;
        _credential = credential;
        _recipes = recipes;
        _reviews = reviews;
        _followers = followers;
    }
    
    public Guid Id => _id;
    public string Username => _username;
    public string Fullname => _fullname;
    public string ImageUrl => _imageUrl;
    public DateTime CreatedAt => _createdAt;
    public Credential Credential => _credential;
    
    public Recipe.Recipe[] Recipes => _recipes;
    public CookReview[] Reviews => _reviews;
    public Follower[] Followers => _followers;

    public class Builder
    {
        private Guid _id;
        private string _userName = string.Empty;
        private string _fullName = string.Empty;
        private string _imageUrl = string.Empty;
        private DateTime _createdAt = DateTime.Now;
        private Credential _credential = Credential.Empty;
        
        private Recipe.Recipe[] _recipes = Array.Empty<Recipe.Recipe>();
        private CookReview[] _reviews = Array.Empty<CookReview>();
        private Follower[] _followers = Array.Empty<Follower>();

        public Builder FromCook(Cook cook)
        {
            _id = cook.Id;
            _userName = cook.Username;
            _fullName = cook.Fullname;
            _imageUrl = cook.ImageUrl;
            _createdAt = cook.CreatedAt;
            _credential = cook.Credential;
            _recipes = cook.Recipes;
            _reviews = cook.Reviews;
            _followers = cook.Followers;
            return this;
        }

        
        public Builder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public Builder WithUsername(string userName)
        {
            _userName = userName;
            return this;
        }

        public Builder WithFullname(string fullName)
        {
            _fullName = fullName;
            return this;
        }

        public Builder WithImageUrl(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }

        public Builder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public Builder WithCredential(Credential credential)
        {
            _credential = credential;
            return this;
        }
        
        public Builder WithRecipes(Recipe.Recipe[] recipes)
        {
            _recipes = recipes;
            return this;
        }
        
        public Builder WithReviews(CookReview[] reviews)
        {
            _reviews = reviews;
            return this;
        }
        
        public Builder WithFollowers(Follower[] followers)
        {
            _followers = followers;
            return this;
        }
        
        public Cook Build()
        {
            return new Cook(_id, _userName, _fullName, _imageUrl, 
                _createdAt, _credential, _recipes, _reviews, _followers);
        }
    }
}