using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface IRecipeReviewService : IReviewService<RecipeReview>
{
    RecipeReview GetForRecipeId(Guid recipeId);
}