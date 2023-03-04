namespace BLL.Entities.Recipe;

public class Recipe
{
    private readonly Guid _id;
    private string _name;
    private string _imageUrl;
    private string _description;
    private TimeSpan _preparationTime;
    private Category _category;
    private readonly DateTime _createdAt;
    private DateTime _updatedAt;
    private Guid _cookId;
    
    private List<Ingredient.Ingredient> _ingredients;
    private List<PreparationStep> _preparationSteps;
    
    public Recipe(Guid id, string name, string imageUrl, string description, TimeSpan preparationTime, Category category, DateTime createdAt, DateTime updatedAt, Guid cookId, List<Ingredient.Ingredient> ingredients, List<PreparationStep> preparationSteps)
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
    
    public List<Ingredient.Ingredient> Ingredients => _ingredients;
    public List<PreparationStep> PreparationSteps => _preparationSteps;
    
    public void SetName(string name)
    {
        _name = name;
    }
    
    public void SetImageUrl(string imageUrl)
    {
        _imageUrl = imageUrl;
    }
    
    public void SetDescription(string description)
    {
        _description = description;
    }
    
    public void SetPreparationTime(TimeSpan preparationTime)
    {
        _preparationTime = preparationTime;
    }
    
    public void SetUpdatedAt(DateTime updatedAt)
    {
        _updatedAt = updatedAt;
    }
    
    public void AddIngredient(Ingredient.Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }
    
    public void RemoveIngredient(Ingredient.Ingredient ingredient)
    {
        _ingredients.Remove(ingredient);
    }
    
    public void AddPreparationStep(PreparationStep preparationStep)
    {
        _preparationSteps.Add(preparationStep);
    }
    
    public void RemovePreparationStep(PreparationStep preparationStep)
    {
        _preparationSteps.Remove(preparationStep);
    }

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
    
        private List<Ingredient.Ingredient> _ingredients = new();
        private List<PreparationStep> _preparationSteps = new();
        
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
        
        public Builder WithIngredients(List<Ingredient.Ingredient> ingredients)
        {
            _ingredients = ingredients;
            return this;
        }
        
        public Builder WithPreparationSteps(List<PreparationStep> preparationSteps)
        {
            _preparationSteps = preparationSteps;
            return this;
        }
        
        public Recipe Build()
        {
            return new Recipe(_id, _name, _imageUrl, _description, _preparationTime, _category, _createdAt, _updatedAt, _cookId, _ingredients, _preparationSteps);
        }
    }
}