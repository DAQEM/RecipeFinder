namespace BLL.Data.Review.Reviewer;

public class ReviewerService : IReviewerService
{
    private readonly IReviewerRepository _reviewerRepository;
    
    public ReviewerService(IReviewerRepository reviewerRepository)
    {
        _reviewerRepository = reviewerRepository;
    }
    
    public Entities.Review.Reviewer? GetReviewerByCookId(Guid cookId)
    {
        return _reviewerRepository.GetReviewerByCookId(cookId);
    }
}