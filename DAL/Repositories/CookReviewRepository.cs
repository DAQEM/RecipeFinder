using BLL.Data.Review;
using BLL.Entities.Cook;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookReviewRepository : ICookReviewRepository
{
    public List<Review> GetAll()
    {
        throw new NotImplementedException();
    }

    public Review GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Review GetByCookUsername(string username)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetByCookId(Guid cookId)
    {
        const string query = "SELECT CookReview.id as 'id', cook_id, rating, comment, CookReview.created_at as 'created_at', username, fullname, image_url " +
                             "FROM CookReview " +
                             "INNER JOIN Cook ON CookReview.reviewer_id = Cook.id " +
                             "WHERE CookReview.cook_id = @cook_id;";
        MySqlParameter[] parameters =
        {
            new("@cook_id", cookId)
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

    public List<Review> GetForCookId(Guid userId)
    {
        throw new NotImplementedException();
    }
}