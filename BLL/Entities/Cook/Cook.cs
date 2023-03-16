using System.Security.Cryptography.X509Certificates;
using BLL.Entities.Review;
using BLL.Exceptions;

namespace BLL.Entities.Cook;

public class Cook
{
    private Guid _id;
    private string _username;
    private string _fullname;
    private string _imageUrl;
    private DateTime _createdAt;
    private Credential _credential;

    private Recipe.Recipe[] _recipes;
    private CookReview[] _reviews;
    private Follower[] _followers;

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
    
    public Guid Id { get => _id; private set => _id = value; }
    public string Username { get => _username; private set => _username = value; }
    public string Fullname { get => _fullname; private set => _fullname = value; }
    public string ImageUrl { get => _imageUrl; private set => _imageUrl = value; }
    public DateTime CreatedAt { get => _createdAt; private set => _createdAt = value; }
    public Credential Credential { get => _credential; private set => _credential = value; }
    
    public Recipe.Recipe[] Recipes { get => _recipes; private set => _recipes = value; }
    public CookReview[] Reviews { get => _reviews; private set => _reviews = value; }
    public Follower[] Followers { get => _followers; private set => _followers = value; }

    private static Cook Empty => new(Guid.Empty, string.Empty, string.Empty, 
        string.Empty, DateTime.Now, Credential.Empty, Array.Empty<Recipe.Recipe>(), 
        Array.Empty<CookReview>(), Array.Empty<Follower>());
    
    public class Builder
    {
        private Cook _cook = Empty;

        public Builder FromCook(Cook cook)
        {
            _cook = cook;
            return this;
        }

        public Builder WithId(Guid id)
        {
            _cook.Id = id;
            return this;
        }

        public Builder WithUsername(string username)
        {
            _cook.Username = username;
            return this;
        }

        public Builder WithFullname(string fullname)
        {
            _cook.Fullname = fullname;
            return this;
        }

        public Builder WithImageUrl(string imageUrl)
        {
            _cook.ImageUrl = imageUrl;
            return this;
        }

        public Builder WithCreatedAt(DateTime createdAt)
        {
            _cook.CreatedAt = createdAt;
            return this;
        }

        public Builder WithCredential(Credential credential)
        {
            _cook.Credential = credential;
            return this;
        }
        
        public Builder WithRecipes(Recipe.Recipe[] recipes)
        {
            _cook.Recipes = recipes;
            return this;
        }
        
        public Builder WithReviews(CookReview[] reviews)
        {
            _cook.Reviews = reviews;
            return this;
        }
        
        public Builder WithFollowers(Follower[] followers)
        {
            _cook.Followers = followers;
            return this;
        }
        
        public Cook Build()
        {
            if (_cook.Id == Guid.Empty || _cook.Username == string.Empty || _cook.Fullname == string.Empty || _cook.ImageUrl == string.Empty)
            {
                throw new IncompleteBuilderException(typeof(Cook));
            }
            return _cook;
        }
    }
}