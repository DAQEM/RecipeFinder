using BLL.Data.Auth;
using BLL.Data.Cook;
using BLL.Data.Cook.Credential;
using BLL.Data.Cook.Follower;
using BLL.Data.Recipe;
using BLL.Data.Recipe.Ingredient;
using BLL.Data.Recipe.Like;
using BLL.Data.Recipe.Preparation;
using BLL.Data.Recipe.Save;
using BLL.Data.Review;
using BLL.Data.Review.Reviewer;
using DAL.Repositories;

namespace MVC;

public static class DependencyInversion
{
    public static void Run(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSingleton<IAuthRepository, AuthRepository>();
        services.AddSingleton<IAuthService, AuthService>();

        services.AddSingleton<IFollowerRepository, FollowerRepository>();
        services.AddSingleton<IFollowerService, FollowerService>();

        services.AddSingleton<IIngredientRepository, IngredientRepository>();
        services.AddSingleton<IIngredientService, IngredientService>();

        services.AddSingleton<ILikeRepository, LikeRepository>();
        services.AddSingleton<ILikeService, LikeService>();

        services.AddSingleton<IPreparationStepRepository, PreparationStepRepository>();
        services.AddSingleton<IPreparationStepService, PreparationStepService>();

        services.AddSingleton<IRecipeRepository, RecipeRepository>();
        services.AddSingleton<IRecipeService, RecipeService>();

        services.AddSingleton<ISaveRepository, SaveRepository>();
        services.AddSingleton<ISaveService, SaveService>();

        services.AddSingleton<IReviewerRepository, ReviewerRepository>();
        services.AddSingleton<IReviewerService, ReviewerService>();

        services.AddSingleton<ICookReviewRepository, CookReviewRepository>();
        services.AddSingleton<ICookReviewService, CookReviewService>();

        services.AddSingleton<IRecipeReviewRepository, RecipeReviewRepository>();
        services.AddSingleton<IRecipeReviewService, RecipeReviewService>();

        services.AddSingleton<ICookRepository, CookRepository>();
        services.AddSingleton<ICookService, CookService>();
        
        services.AddSingleton<ICredentialRepository, CredentialRepository>();
        services.AddSingleton<ICredentialService, CredentialService>();
    }
}