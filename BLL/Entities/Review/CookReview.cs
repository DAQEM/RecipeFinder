namespace BLL.Entities.Review;

public class CookReview : Review
{
    private readonly Guid _cookId;
    
    public CookReview(Guid id, string reviewerFullname, string reviewerImageUrl, string comment, int rating, DateTime createdAt, Guid cookId) 
        : base(id, reviewerFullname, reviewerImageUrl, comment, rating, createdAt)
    {
        _cookId = cookId;
    }
    
    public Guid CookId => _cookId;

    public class Builder : ReviewBuilder<CookReview>
    {
        private Guid _cookId;
        
        public ReviewBuilder<CookReview> WithCookId(Guid cookId)
        {
            _cookId = cookId;
            return this;
        }
        
        public override CookReview Build()
        {
            return new CookReview(Id, ReviewerFullname, ReviewerImageUrl, Comment, Rating, CreatedAt, _cookId);
        }
    }
}