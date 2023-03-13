using BLL.Data.Auth;
using BLL.Data.Cook;
using BLL.Data.Cook.Follower;
using BLL.Data.Recipe;
using BLL.Data.Recipe.Ingredient;
using BLL.Data.Recipe.Like;
using BLL.Data.Recipe.Preparation;
using BLL.Data.Recipe.Save;
using BLL.Data.Review;
using BLL.Data.Review.Reviewer;
using DAL.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

services.AddControllersWithViews().AddRazorRuntimeCompilation();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

services.AddSingleton<IAuthRepository, AuthRepository>();
services.AddSingleton<IAuthService, AuthService>(provider => new AuthService(provider.GetService<IAuthRepository>()));

services.AddSingleton<IFollowerRepository, FollowerRepository>();
services.AddSingleton<IFollowerService, FollowerService>(provider => new FollowerService(provider.GetService<IFollowerRepository>()));

services.AddSingleton<IIngredientRepository, IngredientRepository>();
services.AddSingleton<IIngredientService, IngredientService>(provider => new IngredientService(provider.GetService<IIngredientRepository>()));

services.AddSingleton<ILikeRepository, LikeRepository>();
services.AddSingleton<ILikeService, LikeService>(provider => new LikeService(provider.GetService<ILikeRepository>()));

services.AddSingleton<IPreparationStepRepository, PreparationStepRepository>();
services.AddSingleton<IPreparationStepService, PreparationStepService>(provider => new PreparationStepService(provider.GetService<IPreparationStepRepository>()));

services.AddSingleton<IRecipeRepository, RecipeRepository>();
services.AddSingleton<IRecipeService, RecipeService>(provider => new RecipeService(provider.GetService<IRecipeRepository>()));

services.AddSingleton<ISaveRepository, SaveRepository>();
services.AddSingleton<ISaveService, SaveService>(provider => new SaveService(provider.GetService<ISaveRepository>()));

services.AddSingleton<IReviewerRepository, ReviewerRepository>();
services.AddSingleton<IReviewerService, ReviewerService>(provider => new ReviewerService(provider.GetService<IReviewerRepository>()));

services.AddSingleton<ICookReviewRepository, CookReviewRepository>();
services.AddSingleton<ICookReviewService, CookReviewService>(provider => new CookReviewService(provider.GetService<ICookReviewRepository>()));

services.AddSingleton<IRecipeReviewRepository, RecipeReviewRepository>();
services.AddSingleton<IRecipeReviewService, RecipeReviewService>(provider => new RecipeReviewService(provider.GetService<IRecipeReviewRepository>()));

services.AddSingleton<ICookRepository, CookRepository>(provider => new CookRepository(provider.GetService<IReviewerRepository>(), provider.GetService<IRecipeRepository>(), provider.GetService<ICookReviewRepository>()));
services.AddSingleton<ICookService, CookService>(provider => new CookService(provider.GetService<ICookRepository>()));

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();