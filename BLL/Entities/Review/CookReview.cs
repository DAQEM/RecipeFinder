namespace BLL.Entities.Review;

public class CookReview : Review
{
    private readonly Guid _cookId;

    private CookReview(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer, Guid cookId) 
        : base(id, comment, rating, createdAt, reviewer)
    {
        _cookId = cookId;
    }

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
            return new CookReview(Id, Comment, Rating, CreatedAt, Reviewer, _cookId);
        }
    }
}