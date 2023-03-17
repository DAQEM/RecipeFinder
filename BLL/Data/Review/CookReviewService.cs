using BLL.Entities.Review;

namespace BLL.Data.Review;

public class CookReviewService : ICookReviewService
{
    private readonly ICookReviewRepository _cookReviewRepository;
    
    public CookReviewService(ICookReviewRepository cookReviewRepository)
    {
        _cookReviewRepository = cookReviewRepository;
    }
    
    public Entities.Review.Review GetForCookId(Guid cookId)
    {
        return _cookReviewRepository.GetForCookId(cookId);
    }

    public List<Entities.Review.Review> GetAll()
    {
        throw new NotImplementedException();
    }

    public Entities.Review.Review GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Entities.Review.Review> GetByCookId(Guid cookId)
    {
        return _cookReviewRepository.GetByCookId(cookId);
    }

    public List<Entities.Review.Review> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }

    public void Update(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }

    public void Delete(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }
}