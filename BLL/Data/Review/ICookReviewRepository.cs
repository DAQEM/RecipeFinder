using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface ICookReviewRepository : IReviewRepository<CookReview>
{
    CookReview GetForCookId(Guid userId);
}