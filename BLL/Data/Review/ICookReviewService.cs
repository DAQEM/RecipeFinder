namespace BLL.Data.Review;

public interface ICookReviewService : IReviewService
{
    Entities.Review.Review GetForCookId(Guid cookId);
}