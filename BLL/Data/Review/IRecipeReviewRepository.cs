using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface IRecipeReviewRepository : IReviewRepository<RecipeReview>
{
    RecipeReview GetForRecipeId(Guid recipeId);
}