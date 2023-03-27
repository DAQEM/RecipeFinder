using BLL.Exceptions;

namespace BLL.Data.Review;

public class CookReviewService : ICookReviewService
{
    private readonly ICookReviewRepository _cookReviewRepository;
    
    public CookReviewService(ICookReviewRepository cookReviewRepository)
    {
        _cookReviewRepository = cookReviewRepository;
    }
    
    public List<Entities.Review.Review> GetForCookId(Guid cookId)
    {
        return _cookReviewRepository.GetForCookId(cookId);
    }

    public List<Entities.Review.Review> GetAll()
    {
        return _cookReviewRepository.GetAll();
    }

    public Entities.Review.Review GetById(Guid id)
    {
        Entities.Review.Review? review = _cookReviewRepository.GetById(id);
        return review ?? throw new NotFoundException(typeof(CookReviewService), nameof(GetById), typeof(Entities.Review.Review), id);
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