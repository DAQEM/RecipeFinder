using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Data.Review;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookRepository : ICookRepository
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly ICookReviewRepository _cookReviewRepository;

    public CookRepository(IRecipeRepository recipeRepository,
        ICookReviewRepository cookReviewRepository)
    {
        _recipeRepository = recipeRepository;
        _cookReviewRepository = cookReviewRepository;
    }

    public List<Cook> GetAll()
    {
        const string query = "SELECT Cook.id as 'cook_id', Cook.username, Cook.fullname, Cook.image_url, Cook.created_at, Credential.id as 'credential_id', Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id;";
        
        return QueryHelper.QueryMultiple(query, null,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("cook_id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential(new Credential.Builder()
                    .WithId(reader.GetGuid("credential_id"))
                    .WithEmail(reader.GetString("email"))
                    .WithPassword(reader.GetString("password"))
                    .WithUpdatedAt(reader.GetDateTime("updated_at"))
                    .WithCookId(reader.GetGuid("cook_id"))
                    .Build())
                .Build());
    }

    public Cook? GetById(Guid id)
    {
        const string query = "SELECT Cook.id as 'cook_id', Cook.username, Cook.fullname, Cook.image_url, Cook.created_at, Credential.id as 'credential_id', Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE Cook.id = @id;";
        
        MySqlParameter[] parameters =
        {
            new("@id", id)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("cook_id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential(new Credential.Builder()
                    .WithId(reader.GetGuid("credential_id"))
                    .WithEmail(reader.GetString("email"))
                    .WithPassword(reader.GetString("password"))
                    .WithUpdatedAt(reader.GetDateTime("updated_at"))
                    .WithCookId(reader.GetGuid("cook_id"))
                    .Build())
                .Build());
    }

    public Cook? GetByUserName(string username)
    {
        const string query = "SELECT Cook.id as 'cook_id', Cook.username, Cook.fullname, Cook.image_url, Cook.created_at, Credential.id as 'credential_id', Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE username = @username;";
        
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook.Builder()
                .WithId(reader.GetGuid("cook_id"))
                .WithUsername(reader.GetString("username"))
                .WithFullname(reader.GetString("fullname"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential(new Credential.Builder()
                    .WithId(reader.GetGuid("credential_id"))
                    .WithEmail(reader.GetString("email"))
                    .WithPassword(reader.GetString("password"))
                    .WithUpdatedAt(reader.GetDateTime("updated_at"))
                    .WithCookId(reader.GetGuid("cook_id"))
                    .Build())
                .Build());
    }

    public void Add(Cook cook)
    {
        const string query =
            "INSERT INTO Cook (id, username, fullname, image_url) " +
            "VALUES (@id, @username, @fullname, @image_url);";
        MySqlParameter[] parameters =
        {
            new("@id", cook.Id),
            new("@username", cook.Username),
            new("@fullname", cook.Fullname),
            new("@image_url", cook.ImageUrl ?? "https://i.imgur.com/ShL15rC.png")
        };
        QueryHelper.NonQuery(query, parameters);
    }

    public void Update(Cook cook)
    {
        UpdateCook(cook);
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
    
    public Cook? GetByRecipeIdWithRecipe(Guid recipeId)
    {
        Recipe? recipe = _recipeRepository.GetById(recipeId);
        if (recipe == null) return null;
        Cook? cook = GetById(recipe!.CookId);
        if (cook == null) return null;
        return new Cook.Builder()
            .FromCook(cook)
            .WithRecipes(new[] {recipe})
            .Build();
    }
}