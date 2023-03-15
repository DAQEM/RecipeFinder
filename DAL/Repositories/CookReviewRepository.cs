using BLL.Data.Review;
using BLL.Data.Review.Reviewer;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookReviewRepository : ICookReviewRepository
{
    public List<CookReview> GetAll()
    {
        throw new NotImplementedException();
    }

    public CookReview GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public CookReview GetByCookUsername(string username)
    {
        throw new NotImplementedException();
    }

    public List<CookReview> GetByCookId(Guid cookId)
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
            reader => new CookReview.Builder()
                .WithCookId(reader.GetGuid("cook_id"))
                .WithId(reader.GetGuid("id"))
                .WithRating(reader.GetInt32("rating"))
                .WithComment(reader.GetString("comment"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithReviewer(new Reviewer.Builder()
                    .WithUsername(reader.GetString("username"))
                    .WithFullname(reader.GetString("fullname"))
                    .WithImageUrl(reader.GetString("image_url"))
                    .Build())
                .Build());
    }

    public List<CookReview> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(CookReview review)
    {
        throw new NotImplementedException();
    }

    public void Update(CookReview review)
    {
        throw new NotImplementedException();
    }

    public void Delete(CookReview review)
    {
        throw new NotImplementedException();
    }

    public CookReview GetForCookId(Guid userId)
    {
        throw new NotImplementedException();
    }
}