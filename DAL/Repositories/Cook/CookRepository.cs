using BLL.Data.Cook;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Entities.Review;
using MySql.Data.MySqlClient;

namespace DAL.Repositories.Cook;

public class CookRepository : ICookRepository
{
    public List<BLL.Entities.Cook.Cook> GetAll()
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id;";
        return QueryHelper.QueryMultiple(query, null,
            reader => new BLL.Entities.Cook.Cook.Builder()
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

    public BLL.Entities.Cook.Cook? GetById(Guid id)
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
            reader => new BLL.Entities.Cook.Cook.Builder()
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

    public BLL.Entities.Cook.Cook? GetByUserName(string username)
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
            reader => new BLL.Entities.Cook.Cook.Builder()
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

    public void Add(BLL.Entities.Cook.Cook cook)
    {
        
    }

    public void Update(BLL.Entities.Cook.Cook cook)
    {
        UpdateCook(cook);
        UpdateCredential(cook);
    }

    private static void UpdateCredential(BLL.Entities.Cook.Cook cook)
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

    private static void UpdateCook(BLL.Entities.Cook.Cook cook)
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

    public void Delete(BLL.Entities.Cook.Cook cook)
    {
        
    }
    
    public List<Recipe> GetRecipesByUsername(string username)
    {
        const string query = "SELECT Recipe.*" +
                             "FROM Recipe " +
                             "INNER JOIN Cook ON Recipe.cook_id = Cook.id " +
                             "WHERE Cook.username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe.Builder()
                .WithId(reader.GetGuid("id"))
                .WithName(reader.GetString("name"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithDescription(reader.GetString("description"))
                .WithPreparationTime(reader.GetTimeSpan("preparation_time"))
                .WithCategory((Category)reader.GetInt32("category"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithUpdatedAt(reader.GetDateTime("updated_at"))
                .WithCookId(reader.GetGuid("cook_id"))
                .WithIngredients(null)
                .WithPreparationSteps(null)
                .Build());
    }
    
    public List<CookReview> GetReviewsForUsername(string username)
    {
        const string query = "SELECT CookReview.*" +
                             "FROM CookReview " +
                             "INNER JOIN Cook ON CookReview.cook_id = Cook.id " +
                             "WHERE Cook.username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };

        return QueryHelper.QueryMultiple(query, parameters,
            reader =>
            {
                BLL.Entities.Cook.Cook? reviewer = GetById(reader.GetGuid("reviewer_id"));
                return new CookReview.Builder()
                    .WithCookId(reader.GetGuid("cook_id"))
                    .WithId(reader.GetGuid("id"))
                    .WithRating(reader.GetInt32("rating"))
                    .WithComment(reader.GetString("comment"))
                    .WithCreatedAt(reader.GetDateTime("created_at"))
                    .WithReviewerFullname(reviewer == null ? "" : reviewer.Fullname)
                    .WithReviewerImageUrl(reviewer == null ? "" : reviewer.ImageUrl)
                    .Build();
            });

    }
}