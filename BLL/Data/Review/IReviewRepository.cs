namespace BLL.Data.Review;

public interface IReviewRepository
{
    List<Entities.Review.Review> GetAll();
    Entities.Review.Review? GetById(Guid id);
    List<Entities.Review.Review> GetByCookId(Guid cookId);
    List<Entities.Review.Review> GetByRating(int rating);
    void Add(Guid reviewedId, Entities.Review.Review review);
    void Update(Guid reviewedId, Entities.Review.Review review);
    void Delete(Guid reviewedId, Entities.Review.Review review);
}