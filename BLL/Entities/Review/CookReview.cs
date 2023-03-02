namespace BLL.Entities.Review;

public class CookReview : Review
{
    public CookReview(Guid reviewerId, string comment, int rating, DateTime createdAt) 
        : base(reviewerId, comment, rating, createdAt)
    {
    }
}