using BLL.Data.Auth;
using BLL.Data.Cook;
using BLL.Data.Cook.Credential;
using BLL.Data.Cook.Follower;
using BLL.Data.Recipe;
using BLL.Data.Recipe.Ingredient;
using BLL.Data.Recipe.Preparation;
using BLL.Data.Review;
using DAL.Repositories;

namespace MVC;

public static class DependencyInjection
{
    public static void Run(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IIngredientService, IngredientService>();

        services.AddScoped<IPreparationStepRepository, PreparationStepRepository>();
        services.AddScoped<IPreparationStepService, PreparationStepService>();

        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IRecipeService, RecipeService>();

        services.AddScoped<ICookReviewRepository, CookReviewRepository>();
        services.AddScoped<ICookReviewService, CookReviewService>();

        services.AddScoped<IRecipeReviewRepository, RecipeReviewRepository>();
        services.AddScoped<IRecipeReviewService, RecipeReviewService>();

        services.AddScoped<ICookRepository, CookRepository>();
        services.AddScoped<ICookService, CookService>();
        
        services.AddScoped<ICredentialRepository, CredentialRepository>();
        services.AddScoped<ICredentialService, CredentialService>();
        
        services.AddScoped<IFollowerRepository, FollowerRepository>();
        services.AddScoped<IFollowerService, FollowerService>();
    }
}