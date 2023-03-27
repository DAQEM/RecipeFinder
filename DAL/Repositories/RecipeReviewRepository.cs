using BLL.Data.Review;
using BLL.Entities.Cook;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class RecipeReviewRepository : IRecipeReviewRepository
{
    public List<Review> GetAll()
    {
        throw new NotImplementedException();
    }

    public Review GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetByCookId(Guid cookId)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(Guid reviewedId, Review review)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid reviewedId, Review review)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid reviewedId, Review review)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetForRecipeId(Guid recipeId)
    {
        const string query =
            "SELECT RecipeReview.id as 'id', rating, comment, RecipeReview.created_at as 'created_at', username, fullname, image_url " +
            "FROM RecipeReview " +
            "INNER JOIN Cook ON RecipeReview.reviewer_id = Cook.id " +
            "WHERE RecipeReview.recipe_id = @recipe_id;";
        MySqlParameter[] parameters =
        {
            new("@recipe_id", recipeId)
        };

        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Review(
                id: reader.GetGuid("id"),
                rating: reader.GetInt32("rating"),
                comment: reader.GetString("comment"),
                createdAt: reader.GetDateTime("created_at"),
                reviewer: new Cook(
                    username: reader.GetString("username"),
                    fullname: reader.GetString("fullname"),
                    imageUrl: reader.GetString("image_url"))));
    }
}