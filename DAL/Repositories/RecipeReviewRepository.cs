using BLL.Data.Review;
using BLL.Entities.Review;

namespace DAL.Repositories;

public class RecipeReviewRepository : IRecipeReviewRepository
{
    public List<Review> GetAll()
    {
        throw new NotImplementedException();
    }

    public Review GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetByCookId(Guid cookId)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(Review review)
    {
        throw new NotImplementedException();
    }

    public void Update(Review review)
    {
        throw new NotImplementedException();
    }

    public void Delete(Review review)
    {
        throw new NotImplementedException();
    }

    public Review GetForRecipeId(Guid recipeId)
    {
        throw new NotImplementedException();
    }
}