namespace BLL.Entities.Cook;

public class Cook
{
    private readonly Guid _id;
    private readonly string _username;
    private readonly string _fullname;
    private readonly string _imageUrl;
    private readonly DateTime _createdAt;
    private Credential _credential;

    private Recipe.Recipe[] _recipes;
    private Review.Review[] _reviews;
    private Cook[] _following;

    public Cook(Guid? id = null, string username = "", string fullname = "", string imageUrl = "", 
        DateTime? createdAt = null, Credential? credential = null, Recipe.Recipe[]? recipes = null, 
        Review.Review[]? reviews = null, Cook[]? followers = null)
    {
        _id = id ?? Guid.Empty;
        _username = username;
        _fullname = fullname;
        _imageUrl = imageUrl;
        _createdAt = createdAt ?? DateTime.MinValue;
        _credential = credential ?? new Credential();
        
        _recipes = recipes ?? Array.Empty<Recipe.Recipe>();
        _reviews = reviews ?? Array.Empty<Review.Review>();
        _following = followers ?? Array.Empty<Cook>();
    }

    public Guid Id => _id;
    public string Username => _username;
    public string Fullname => _fullname;
    public string ImageUrl => _imageUrl;
    public DateTime CreatedAt => _createdAt;
    public Credential Credential => _credential;
    
    public Recipe.Recipe[] Recipes => _recipes;
    public Review.Review[] Reviews => _reviews;
    public Cook[] Following => _following;

    public void SetReviews(List<Review.Review> reviews)
    {
        _reviews = reviews.ToArray();
    }
    
    public void SetRecipes(List<Recipe.Recipe> recipes)
    {
        _recipes = recipes.ToArray();
    }
    
    public void SetFollowing(List<Cook> followers)
    {
        _following = followers.ToArray();
    }

    public void SetCredential(Credential credential)
    {
        _credential = credential;
    }
}