namespace BLL.Data.Review.Reviewer;

public interface IReviewerService
{
    Entities.Review.Reviewer? GetReviewerByCookId(Guid cookId);
}