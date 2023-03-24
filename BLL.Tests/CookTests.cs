using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Entities.Review;

namespace BLL.Tests;

public class Tests
{

    [Test]
    public void SetReviewsTest()
    {
        //Arrange
        Cook cook = new();
        List<Review> reviews = new() { new Review(), new Review(), new Review() };
        
        //Act
        cook.SetReviews(reviews);
        
        //Assert
        Assert.That(cook.Reviews, Is.EqualTo(reviews));
    }

    [Test]
    public void SetRecipesTest()
    {
        //Arrange
        Cook cook = new();
        List<Recipe> recipes = new() { new Recipe(), new Recipe(), new Recipe() };

        //Act
        cook.SetRecipes(recipes);

        //Assert
        Assert.That(cook.Recipes, Is.EqualTo(recipes));
    }

    [Test]
    public void SetFollowersTest()
    {
        //Arrange
        Cook cook = new();
        List<Cook> following = new() { new Cook(), new Cook(), new Cook() };

        //Act
        cook.SetFollowing(following);

        //Assert
        Assert.That(cook.Following, Is.EqualTo(following));
    }

    [Test]
    public void SetCredentialTest()
    {
        //Arrange
        Cook cook = new();
        Credential credential = new();

        //Act
        cook.SetCredential(credential);

        //Assert
        Assert.That(cook.Credential, Is.EqualTo(credential));
    }
}