using System.Net.Mail;
using BLL.Entities.Review;

namespace BLL.Entities.Recipe;

public class Recipe
{
    private Guid _id;
    private string _name;
    private string _imageUrl;
    private string _description;
    private TimeSpan _preparationTime;
    private Category _category;
    private DateTime _createdAt;
    private DateTime _updatedAt;
    private Guid _cookId;
    
    private Ingredient.Ingredient[] _ingredients;
    private PreparationStep[] _preparationSteps;
    private RecipeReview[] _reviews;
    private Liker[] _likers;
    private Saver[] _savers;
    
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

    public Guid Id { get => _id; private set => _id = value;}
    public string Name { get => _name; private set => _name = value;}
    public string ImageUrl { get => _imageUrl; private set => _imageUrl = value;}
    public string Description { get => _description; private set => _description = value;}
    public TimeSpan PreparationTime { get => _preparationTime; private set => _preparationTime = value;}
    public Category Category { get => _category; private set => _category = value;}
    public DateTime CreatedAt { get => _createdAt; private set => _createdAt = value;}
    public DateTime UpdatedAt { get => _updatedAt; private set => _updatedAt = value;}
    public Guid CookId { get => _cookId; private set => _cookId = value;}
    
    public Ingredient.Ingredient[] Ingredients { get => _ingredients; private set => _ingredients = value;}
    public PreparationStep[] PreparationSteps { get => _preparationSteps; private set => _preparationSteps = value;}
    public RecipeReview[] Reviews { get => _reviews; private set => _reviews = value;}
    public Liker[] Likers { get => _likers; private set => _likers = value;}
    public Saver[] Savers { get => _savers; private set => _savers = value;}

    private static Recipe Empty => new(Guid.Empty, string.Empty, string.Empty, string.Empty, 
        TimeSpan.Zero, Category.Other, DateTime.Now, DateTime.Now, Guid.Empty, 
        Array.Empty<Ingredient.Ingredient>(), Array.Empty<PreparationStep>(), 
        Array.Empty<RecipeReview>(), Array.Empty<Liker>(), Array.Empty<Saver>());
    
    public class Builder
    {
        private readonly Recipe _recipe = Empty;
        
        public Builder WithId(Guid id)
        {
            _recipe.Id = id;
            return this;
        }
        
        public Builder WithName(string name)
        {
            _recipe.Name = name;
            return this;
        }
        
        public Builder WithImageUrl(string imageUrl)
        {
            _recipe.ImageUrl = imageUrl;
            return this;
        }
        
        public Builder WithDescription(string description)
        {
            _recipe.Description = description;
            return this;
        }
        
        public Builder WithPreparationTime(TimeSpan preparationTime)
        {
            _recipe.PreparationTime = preparationTime;
            return this;
        }
        
        public Builder WithCategory(Category category)
        {
            _recipe.Category = category;
            return this;
        }
        
        public Builder WithCreatedAt(DateTime createdAt)
        {
            _recipe.CreatedAt = createdAt;
            return this;
        }
        
        public Builder WithUpdatedAt(DateTime updatedAt)
        {
            _recipe.UpdatedAt = updatedAt;
            return this;
        }
        
        public Builder WithCookId(Guid cookId)
        {
            _recipe.CookId = cookId;
            return this;
        }
        
        public Builder WithIngredients(Ingredient.Ingredient[] ingredients)
        {
            _recipe.Ingredients = ingredients;
            return this;
        }
        
        public Builder WithPreparationSteps(PreparationStep[] preparationSteps)
        {
            _recipe.PreparationSteps = preparationSteps;
            return this;
        }
        
        public Builder WithReviews(RecipeReview[] reviews)
        {
            _recipe.Reviews = reviews;
            return this;
        }
        
        public Builder WithLikers(Liker[] likers)
        {
            _recipe.Likers = likers;
            return this;
        }
        
        public Builder WithSavers(Saver[] savers)
        {
            _recipe.Savers = savers;
            return this;
        }
        
        public Recipe Build()
        {
            return _recipe;
        }
    }
}