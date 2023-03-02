namespace BLL.Data.Review;

public interface IReviewRepository<T> where T : Entities.Review.Review
{
    public List<T> GetAll();
    public T GetById(Guid id);
    public T GetByCookId(Guid cookId);
    public T GetByRating(int rating);
    public void Add(T review);
    public void Update(T review);
    public void Delete(T review);
}