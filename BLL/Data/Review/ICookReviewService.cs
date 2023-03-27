namespace BLL.Data.Review;

public interface ICookReviewService : IReviewService
{
    List<Entities.Review.Review> GetForCookId(Guid cookId);
}