using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface IRecipeReviewRepository : IReviewRepository
{
    List<Entities.Review.Review> GetForRecipeId(Guid recipeId);
}