using BLL.Data.Review.Reviewer;
using BLL.Entities.Review;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class ReviewerRepository : IReviewerRepository
{
    public Reviewer? GetReviewerByCookId(Guid cookId)
    {
        const string query = "SELECT fullname, username, image_url FROM Cook WHERE id = @cookId;";
        
        MySqlParameter[] parameters =
        {
            new("@cookId", cookId)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Reviewer(
                reader.GetString("fullname"),
                reader.GetString("username"),
                reader.GetString("image_url")))!;
    }
}