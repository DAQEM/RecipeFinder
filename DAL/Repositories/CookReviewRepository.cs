using BLL.Data.Review;
using BLL.Data.Review.Reviewer;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookReviewRepository : ICookReviewRepository
{
    private readonly IReviewerRepository _reviewerRepository;
    
    public CookReviewRepository(IReviewerRepository reviewerRepository)
    {
        _reviewerRepository = reviewerRepository;
    }

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

    public List<CookReview> GetReviewsByCookUsername(string username)
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
                Reviewer? reviewer = _reviewerRepository.GetReviewerByCookId(reader.GetGuid("reviewer_id"));
                return new CookReview.Builder()
                    .WithCookId(reader.GetGuid("cook_id"))
                    .WithId(reader.GetGuid("id"))
                    .WithRating(reader.GetInt32("rating"))
                    .WithComment(reader.GetString("comment"))
                    .WithCreatedAt(reader.GetDateTime("created_at"))
                    .WithReviewer(reviewer ?? Reviewer.Empty)
                    .Build();
            });
    }

    public CookReview GetByRating(int rating)
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