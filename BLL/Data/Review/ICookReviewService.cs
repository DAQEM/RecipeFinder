using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface ICookReviewService : IReviewService<CookReview>
{
    CookReview GetForCookId(Guid cookId);
}