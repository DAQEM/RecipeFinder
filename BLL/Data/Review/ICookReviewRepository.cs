using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface ICookReviewRepository : IReviewRepository
{
    Entities.Review.Review GetForCookId(Guid userId);
}