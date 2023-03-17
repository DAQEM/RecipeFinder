namespace BLL.Data.Review;

public interface IReviewService
{
    List<Entities.Review.Review> GetAll();
    Entities.Review.Review GetById(Guid id);
    List<Entities.Review.Review> GetByCookId(Guid cookId);
    List<Entities.Review.Review> GetByRating(int rating);
    void Add(Entities.Review.Review review);
    void Update(Entities.Review.Review review);
    void Delete(Entities.Review.Review review);
}