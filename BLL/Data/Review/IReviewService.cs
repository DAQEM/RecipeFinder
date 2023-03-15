namespace BLL.Data.Review;

public interface IReviewService <T> where T : Entities.Review.Review
{
    List<T> GetAll();
    T GetById(Guid id);
    List<T> GetByCookId(Guid cookId);
    List<T> GetByRating(int rating);
    void Add(T review);
    void Update(T review);
    void Delete(T review);
}