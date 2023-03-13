using BLL.Entities.Review;

namespace BLL.Data.Review;

public class CookReviewService : ICookReviewService
{
    private readonly ICookReviewRepository _recipeReviewRepository;
    
    public CookReviewService(ICookReviewRepository recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public CookReview GetForCookId(Guid cookId)
    {
        return _recipeReviewRepository.GetForCookId(cookId);
    }

    public List<CookReview> GetAll()
    {
        throw new NotImplementedException();
    }

    public CookReview GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public CookReview GetByCookUsername(string username)
    {
        throw new NotImplementedException();
    }

    public CookReview GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(CookReview review)
    {
        throw new NotImplementedException();
    }

    public void Update(CookReview review)
    {
        throw new NotImplementedException();
    }

    public void Delete(CookReview review)
    {
        throw new NotImplementedException();
    }
}