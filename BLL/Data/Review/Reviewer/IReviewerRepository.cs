namespace BLL.Data.Review.Reviewer;

public interface IReviewerRepository
{
    Entities.Review.Reviewer? GetReviewerByCookId(Guid cookId);
}