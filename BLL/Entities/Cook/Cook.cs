using BLL.Entities.Review;

namespace BLL.Entities.Cook;

public class Cook
{
    private Cook(Guid id, string username, string fullname, string imageUrl, 
        DateTime createdAt, Credential credential, Recipe.Recipe[] recipes, 
        CookReview[] reviews, Follower[] followers)
    {
        Id = id;
        Username = username;
        Fullname = fullname;
        ImageUrl = imageUrl;
        CreatedAt = createdAt;
        Credential = credential;
        Recipes = recipes;
        Reviews = reviews;
        Followers = followers;
    }
    
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Fullname { get; private set; }
    public string ImageUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Credential Credential { get; private set; }
    public Recipe.Recipe[] Recipes { get; private set; }
    public CookReview[] Reviews { get; private set; }
    public Follower[] Followers { get; private set; }

    public class Builder
    {
        private Cook _cook;

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
            return _cook;
        }
    }
}