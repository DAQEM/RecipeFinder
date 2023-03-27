using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Entities.Recipe.Ingredient;
using BLL.Entities.Review;

namespace BLL.Tests;

public class RecipeTests
{
    [Test]
    public void SetSavers_ShouldSetRecipeReviewsToGivenReviewsList()
    {
        //Arrange
        Recipe recipe = new();
        List<Review> reviews = new() { new Review(), new Review(), new Review() };
        
        //Act
        recipe.SetReviews(reviews);
        
        //Assert
        Assert.That(recipe.Reviews, Is.EqualTo(reviews));
    }
    
    [Test]
    public void SetSavers_ShouldSetRecipeIngredientsToGivenIngredientsList()
    {
        //Arrange
        Recipe recipe = new();
        List<Ingredient> ingredients = new() { new Ingredient("", "",1, Unit.Cup), new Ingredient("", "",1, Unit.Cup), new Ingredient("", "",1, Unit.Cup) };
        
        //Act
        recipe.SetIngredients(ingredients);
        
        //Assert
        Assert.That(recipe.Ingredients, Is.EqualTo(ingredients));
    }
    
    [Test]
    public void SetSavers_ShouldSetRecipePreparationStepsToGivenPreparationStepsList()
    {
        //Arrange
        Recipe recipe = new();
        List<PreparationStep> preparationSteps = new() { new PreparationStep(), new PreparationStep(), new PreparationStep() };
        
        //Act
        recipe.SetPreparationSteps(preparationSteps);
        
        //Assert
        Assert.That(recipe.PreparationSteps, Is.EqualTo(preparationSteps));
    }
    
    [Test]
    public void SetSavers_ShouldSetRecipeLikersToGivenLikersList()
    {
        //Arrange
        Recipe recipe = new();
        List<Cook> likers = new() { new Cook(), new Cook(), new Cook() };
        
        //Act
        recipe.SetLikers(likers);
        
        //Assert
        Assert.That(recipe.Likers, Is.EqualTo(likers));
    }
    
    [Test]
    public void SetSavers_ShouldSetRecipeSaversToGivenSaversList()
    {
        //Arrange
        Recipe recipe = new();
        List<Cook> savers = new() { new Cook(), new Cook(), new Cook() };
        
        //Act
        recipe.SetSavers(savers);
        
        //Assert
        Assert.That(recipe.Savers, Is.EqualTo(savers));
    }
    
}