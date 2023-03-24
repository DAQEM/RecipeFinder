using BLL.Data.Recipe;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class RecipeRepository : IRecipeRepository
{
    public Recipe? GetById(Guid id)
    {
        const string query = "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                       "FROM Recipe " +
                       "WHERE Recipe.id = @id;";
        
        MySqlParameter[] parameters = 
        {
            new("@id", id)
        };
        
        return QueryHelper.QuerySingle(query, parameters, 
            reader => new Recipe( 
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetByCookId(Guid cookId)
    {
        const string query = "SELECT id, name, Recipe.image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                             "FROM Recipe " +
                             "WHERE cook_id = @cook_id;";
        MySqlParameter[] parameters =
        {
            new("@cook_id", cookId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetBySearch(string searchString)
    {
        const string query = "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                             "FROM Recipe " +
                             "WHERE name LIKE @search_string;";
        MySqlParameter[] parameters =
        {
            new("@search_string", $"%{searchString}%")
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetLikedByCookId(Guid cookId)
    {
        const string query =
            "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
            "FROM Recipe " +
            "WHERE id IN (SELECT recipe_id FROM Likes WHERE cook_id = @cook_id);";

        MySqlParameter[] parameters =
        {
            new("@cook_id", cookId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetSavedByCookId(Guid cookId)
    {
        const string query =
            "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
            "FROM Recipe " +
            "WHERE id IN (SELECT recipe_id FROM Save WHERE cook_id = @cook_id);";

        MySqlParameter[] parameters =
        {
            new("@cook_id", cookId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public void Update(Recipe recipe)
    {
        const string query = "UPDATE Recipe " +
                             "SET name = @name, image_url = @image_url, description = @description, preparation_time = @preparation_time, category = @category, updated_at = @updated_at " +
                             "WHERE id = @id;";
        MySqlParameter[] parameters =
        {
            new("@name", recipe.Name),
            new("@image_url", recipe.ImageUrl),
            new("@description", recipe.Description),
            new("@preparation_time", recipe.PreparationTime),
            new("@category", (int)recipe.Category),
            new("@updated_at", DateTime.Now),
            new("@id", recipe.Id)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }

    public void Create(Recipe recipe)
    {
        const string query = "INSERT INTO Recipe (id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id) " +
                             "VALUES (@id, @name, @image_url, @description, @preparation_time, @category, @created_at, @updated_at, @cook_id);";
        MySqlParameter[] parameters =
        {
            new("@id", recipe.Id),
            new("@name", recipe.Name),
            new("@image_url", recipe.ImageUrl),
            new("@description", recipe.Description),
            new("@preparation_time", recipe.PreparationTime),
            new("@category", (int)recipe.Category),
            new("@created_at", DateTime.Now),
            new("@updated_at", DateTime.Now),
            new("@cook_id", recipe.CookId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }
}