namespace BLL.Entities.Review;

public class RecipeReview : Review
{
    public RecipeReview(Guid id, string reviewerName, string reviewerImageUrl, string comment, int rating, DateTime createdAt) 
        : base(id, reviewerName, reviewerImageUrl, comment, rating, createdAt)
    {
    }
}