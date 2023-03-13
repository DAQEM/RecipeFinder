using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Data.Review;
using BLL.Data.Review.Reviewer;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookRepository : ICookRepository
{
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly ICookReviewRepository _cookReviewRepository;

    public CookRepository(IReviewerRepository reviewerRepository, IRecipeRepository recipeRepository,
        ICookReviewRepository cookReviewRepository)
    {
        _reviewerRepository = reviewerRepository;
        _recipeRepository = recipeRepository;
        _cookReviewRepository = cookReviewRepository;
    }

    public List<Cook> GetAll()
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id;";
        return QueryHelper.QueryMultiple(query, null,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public Cook? GetById(Guid id)
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE Cook.id = @id;";
        MySqlParameter[] parameters =
        {
            new("@id", id)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public Cook? GetByUserName(string username)
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public void Add(Cook cook)
    {
        
    }

    public void Update(Cook cook)
    {
        UpdateCook(cook);
        UpdateCredential(cook);
    }

    private static void UpdateCredential(Cook cook)
    {
        const string credentialQuery = "UPDATE Credential " +
                                       "SET email = @email " +
                                       "WHERE cook_id = @cook_id;";

        MySqlParameter[] credentialParameters =
        {
            new("@email", cook.Credential.Email),
            new("@cook_id", cook.Id)
        };

        QueryHelper.NonQuery(credentialQuery, credentialParameters);
    }

    private static void UpdateCook(Cook cook)
    {
        const string cookQuery = "UPDATE Cook " +
                                 "SET username = @username, fullname = @fullname, image_url = @image_url " +
                                 "WHERE id = @id;";

        MySqlParameter[] cookParameters =
        {
            new("@username", cook.Username),
            new("@fullname", cook.Fullname),
            new("@image_url", cook.ImageUrl),
            new("@id", cook.Id)
        };

        QueryHelper.NonQuery(cookQuery, cookParameters);
    }

    public void Delete(string username)
    {
        const string query = "DELETE FROM Cook WHERE username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        QueryHelper.NonQuery(query, parameters);
    }

    public Cook? GetByUsernameWithRecipes(string username)
    {
        Cook? cook = GetByUserName(username);
        List<Recipe> recipes = _recipeRepository.GetRecipesByUsername(username);
        
        return new Cook.Builder()
            .WithCook(cook!)
            .WithRecipes(recipes.ToArray())
            .Build();
    }

    public Cook? GetByUsernameWithCookReviews(string username)
    {
        Cook? cook = GetByUserName(username);
        List<CookReview> cookReviews = _cookReviewRepository.GetReviewsByCookUsername(username);
        
        return new Cook.Builder()
            .WithCook(cook!)
            .WithReviews(cookReviews.ToArray())
            .Build();
    }
}