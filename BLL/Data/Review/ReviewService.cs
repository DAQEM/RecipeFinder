namespace BLL.Data.Review;

public class ReviewService<T> where T : Entities.Review.Review
{
    private readonly IReviewRepository<T> _recipeReviewRepository;

    public ReviewService(IReviewRepository<T> recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public List<T> GetAll()
    {
        return _recipeReviewRepository.GetAll();
    }
    
    public T GetById(Guid id)
    {
        return _recipeReviewRepository.GetById(id);
    }


    public T GetByCookId(Guid cookId)
    {
        return _recipeReviewRepository.GetByCookId(cookId);
    }

    public T GetByRating(int rating)
    {
        return _recipeReviewRepository.GetByRating(rating);
    }
    
    public void Add(T cook)
    {
        _recipeReviewRepository.Add(cook);
    }
    
    public void Update(T cook)
    {
        _recipeReviewRepository.Update(cook);
    }
    
    public void Delete(T cook)
    {
        _recipeReviewRepository.Delete(cook);
    }
}