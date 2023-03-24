using BLL.Data.Recipe.Ingredient;
using BLL.Data.Recipe.Liker;
using BLL.Data.Recipe.Preparation;
using BLL.Data.Recipe.Saver;
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
    private readonly ILikerService _likerService;
    private readonly ISaverService _saverService;
    
    public RecipeService(IRecipeRepository recipeRepository, IIngredientService ingredientService, 
        IPreparationStepService preparationStepService, IRecipeReviewService recipeReviewService,
        ILikerService likerService, ISaverService saverService)
    {
        _recipeRepository = recipeRepository;
        _ingredientService = ingredientService;
        _preparationStepService = preparationStepService;
        _recipeReviewService = recipeReviewService;
        _likerService = likerService;
        _saverService = saverService;
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
        List<Entities.Cook.Cook> likers = _likerService.GetForRecipeId(id);
        List<Entities.Cook.Cook> savers = _saverService.GetForRecipeId(id);
        
        recipe.SetIngredients(ingredients);
        recipe.SetPreparationSteps(preparationSteps);
        recipe.SetLikers(likers);
        recipe.SetSavers(savers);

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

    public List<Entities.Recipe.Recipe> GetLikedByCookId(Guid cookId)
    {
        return _recipeRepository.GetLikedByCookId(cookId);
    }

    public List<Entities.Recipe.Recipe> GetSavedByCookId(Guid cookId)
    {
        return _recipeRepository.GetSavedByCookId(cookId);
    }

    public void UpdateWithIngredientsAndPreparationSteps(Guid recipeId, Entities.Recipe.Recipe recipe)
    {
        _recipeRepository.Update(recipe);
        _ingredientService.UpdateForRecipeId(recipeId, recipe.Ingredients);
        _preparationStepService.UpdateForRecipeId(recipeId, recipe.PreparationSteps);
    }

    public void CreateWithIngredientsAndPreparationSteps(Entities.Recipe.Recipe recipe, Guid viewerId)
    {
        _recipeRepository.Create(recipe);
        _ingredientService.CreateForRecipeId(recipe.Id, recipe.Ingredients);
        _preparationStepService.CreateForRecipeId(recipe.Id, recipe.PreparationSteps);
    }
}