using BLL.Entities.Review;

namespace BLL.Data.Review;

public class CookReviewService : ICookReviewService
{
    private readonly ICookReviewRepository _cookReviewRepository;
    
    public CookReviewService(ICookReviewRepository cookReviewRepository)
    {
        _cookReviewRepository = cookReviewRepository;
    }
    
    public CookReview GetForCookId(Guid cookId)
    {
        return _cookReviewRepository.GetForCookId(cookId);
    }

    public List<CookReview> GetAll()
    {
        throw new NotImplementedException();
    }

    public CookReview GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<CookReview> GetByCookId(Guid cookId)
    {
        return _cookReviewRepository.GetByCookId(cookId);
    }

    public List<CookReview> GetByRating(int rating)
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