using BLL.Entities.Review;

namespace BLL.Entities.Recipe;

public class Recipe
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _imageUrl;
    private readonly string _description;
    private readonly TimeSpan _preparationTime;
    private readonly Category _category;
    private readonly DateTime _createdAt;
    private readonly DateTime _updatedAt;
    private readonly Guid _cookId;
    
    private readonly Ingredient.Ingredient[] _ingredients;
    private readonly PreparationStep[] _preparationSteps;
    private readonly RecipeReview[] _reviews;
    private readonly Liker[] _likers;
    private readonly Saver[] _savers;
    
    private Recipe(Guid id, string name, string imageUrl, string description, 
        TimeSpan preparationTime, Category category, DateTime createdAt, 
        DateTime updatedAt, Guid cookId, Ingredient.Ingredient[] ingredients, 
        PreparationStep[] preparationSteps, RecipeReview[] reviews, Liker[] likers, 
        Saver[] savers)
    {
        _id = id;
        _name = name;
        _imageUrl = imageUrl;
        _description = description;
        _preparationTime = preparationTime;
        _category = category;
        _createdAt = createdAt;
        _updatedAt = updatedAt;
        _cookId = cookId;
        _ingredients = ingredients;
        _preparationSteps = preparationSteps;
        _reviews = reviews;
        _likers = likers;
        _savers = savers;
    }

    public Guid Id => _id;
    public string Name => _name;
    public string ImageUrl => _imageUrl;
    public string Description => _description;
    public TimeSpan PreparationTime => _preparationTime;
    public Category Category => _category;
    public DateTime CreatedAt => _createdAt;
    public DateTime UpdatedAt => _updatedAt;
    public Guid CookId => _cookId;
    
    public Ingredient.Ingredient[] Ingredients => _ingredients;
    public PreparationStep[] PreparationSteps => _preparationSteps;
    public RecipeReview[] Reviews => _reviews;
    public Liker[] Likers => _likers;
    public Saver[] Savers => _savers;

    public class Builder
    {
        private Guid _id;
        private string _name = string.Empty;
        private string _imageUrl = string.Empty;
        private string _description = string.Empty;
        private TimeSpan _preparationTime = TimeSpan.Zero;
        private Category _category = Category.Other;
        private DateTime _createdAt = DateTime.Now;
        private DateTime _updatedAt = DateTime.Now;
        private Guid _cookId;

        private Ingredient.Ingredient[] _ingredients = Array.Empty<Ingredient.Ingredient>();
        private PreparationStep[] _preparationSteps = Array.Empty<PreparationStep>();
        private RecipeReview[] _reviews = Array.Empty<RecipeReview>();
        private Liker[] _likers = Array.Empty<Liker>();
        private Saver[] _savers = Array.Empty<Saver>();
        
        public Builder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        
        public Builder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public Builder WithImageUrl(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }
        
        public Builder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public Builder WithPreparationTime(TimeSpan preparationTime)
        {
            _preparationTime = preparationTime;
            return this;
        }
        
        public Builder WithCategory(Category category)
        {
            _category = category;
            return this;
        }
        
        public Builder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public Builder WithUpdatedAt(DateTime updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
        
        public Builder WithCookId(Guid cookId)
        {
            _cookId = cookId;
            return this;
        }
        
        public Builder WithIngredients(Ingredient.Ingredient[] ingredients)
        {
            _ingredients = ingredients;
            return this;
        }
        
        public Builder WithPreparationSteps(PreparationStep[] preparationSteps)
        {
            _preparationSteps = preparationSteps;
            return this;
        }
        
        public Builder WithReviews(RecipeReview[] reviews)
        {
            _reviews = reviews;
            return this;
        }
        
        public Builder WithLikers(Liker[] likers)
        {
            _likers = likers;
            return this;
        }
        
        public Builder WithSavers(Saver[] savers)
        {
            _savers = savers;
            return this;
        }
        
        public Recipe Build()
        {
            return new Recipe(_id, _name, _imageUrl, _description, 
                _preparationTime, _category, _createdAt, _updatedAt, 
                _cookId, _ingredients, _preparationSteps, _reviews, 
                _likers, _savers);
        }
    }
}