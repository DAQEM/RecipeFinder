using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface ICookReviewRepository : IReviewRepository
{
    List<Entities.Review.Review> GetForCookId(Guid userId);
}