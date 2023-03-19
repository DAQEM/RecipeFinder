using BLL.Data.Recipe.Ingredient;
using BLL.Data.Recipe.Preparation;
using BLL.Data.Review;
using BLL.Entities.Recipe;
using BLL.Exceptions;

namespace BLL.Data.Recipe;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientService _ingredientService;
    private readonly IPreparationStepService _preparationStepService;
    private readonly IRecipeReviewService _recipeReviewService;
    
    public RecipeService(IRecipeRepository recipeRepository, IIngredientService ingredientService, 
        IPreparationStepService preparationStepService, IRecipeReviewService recipeReviewService)
    {
        _recipeRepository = recipeRepository;
        _ingredientService = ingredientService;
        _preparationStepService = preparationStepService;
        _recipeReviewService = recipeReviewService;
    }
    
    public Entities.Recipe.Recipe GetById(Guid id)
    {
        Entities.Recipe.Recipe? recipe = _recipeRepository.GetById(id);
        return recipe ?? throw new NotFoundException(typeof(RecipeService), nameof(GetById), typeof(Entities.Recipe.Recipe), id);
    }
    
    public Entities.Recipe.Recipe GetByIdWithReviews(Guid id)
    {
        Entities.Recipe.Recipe recipe = GetById(id);
        List<Entities.Review.Review> reviews = _recipeReviewService.GetForRecipeId(id);
        recipe.SetReviews(reviews);
        return recipe;
    }

    public Entities.Recipe.Recipe GetByIdDetailed(Guid id)
    {
        Entities.Recipe.Recipe recipe = GetByIdWithReviews(id);
        List<Entities.Recipe.Ingredient.Ingredient> ingredients = _ingredientService.GetByRecipeId(id);
        List<PreparationStep> preparationSteps = _preparationStepService.GetByRecipeId(id);
        
        recipe.SetIngredients(ingredients);
        recipe.SetPreparationSteps(preparationSteps);

        return recipe;
    }


    public List<Entities.Recipe.Recipe> GetByCookId(Guid cookId)
    {
        return _recipeRepository.GetByCookId(cookId);
    }
    
    public List<Entities.Recipe.Recipe> GetByCookIdWithReviews(Guid cookId)
    {
        List<Entities.Recipe.Recipe> recipe = _recipeRepository.GetByCookId(cookId);
        foreach (Entities.Recipe.Recipe r in recipe)
        {
            List<Entities.Review.Review> reviews = _recipeReviewService.GetForRecipeId(r.Id);
            r.SetReviews(reviews);
        }
        return recipe;
    }

    public List<Entities.Recipe.Recipe> GetBySearch(string searchString)
    {
        return _recipeRepository.GetBySearch(searchString);
    }
}