namespace BLL.Data.Review;

public interface IReviewRepository<T> where T : Entities.Review.Review
{
    List<T> GetAll();
    T GetById(Guid id);
    T GetByCookUsername(string username);
    
    List<T> GetReviewsByCookUsername(string username);
    T GetByRating(int rating);
    void Add(T review);
    void Update(T review);
    void Delete(T review);
}