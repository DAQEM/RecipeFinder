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
    private readonly Review.Review[] _reviews;
    private readonly Cook.Cook[] _likers;
    private readonly Cook.Cook[] _savers;
    
    public Recipe(Guid? id = null, string name = "", string imageUrl = "", string description = "", 
        TimeSpan? preparationTime = null, Category? category = null, DateTime? createdAt = null, 
        DateTime? updatedAt = null, Guid? cookId = null, Ingredient.Ingredient[]? ingredients = null, 
        PreparationStep[]? preparationSteps = null, Review.Review[]? reviews = null, Cook.Cook[]? likers = null,
        Cook.Cook[]? savers = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _imageUrl = imageUrl;
        _description = description;
        _preparationTime = preparationTime ?? TimeSpan.Zero;
        _category = category ?? Category.None;
        _createdAt = createdAt ?? DateTime.MinValue;
        _updatedAt = updatedAt ?? DateTime.MinValue;
        _cookId = cookId ?? Guid.Empty;
        _ingredients = ingredients ?? Array.Empty<Ingredient.Ingredient>();
        _preparationSteps = preparationSteps ?? Array.Empty<PreparationStep>();
        _reviews = reviews ?? Array.Empty<Review.Review>();
        _likers = likers ?? Array.Empty<Cook.Cook>();
        _savers = savers ?? Array.Empty<Cook.Cook>();
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
    public Review.Review[] Reviews => _reviews;
    public Cook.Cook[] Likers => _likers;
    public Cook.Cook[] Savers => _savers;
}