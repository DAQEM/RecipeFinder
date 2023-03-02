namespace BLL.Entities.Review;

public class RecipeReview : Review
{
    public RecipeReview(Guid reviewerId, string comment, int rating, DateTime createdAt) 
        : base(reviewerId, comment, rating, createdAt)
    {
    }
}