namespace BLL.Entities.Review;

public class CookReview : Review
{
    private Guid _cookId;

    //For Builder only
    public CookReview() : base(Guid.Empty, string.Empty, 0, DateTime.Now, Reviewer.Empty)
    {
        _cookId = Guid.Empty;
    }
    
    private CookReview(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer, Guid cookId) 
        : base(id, comment, rating, createdAt, reviewer)
    {
        _cookId = cookId;
    }
    
    public Guid CookId { get => _cookId; private set => _cookId = value; }

    public class Builder : ReviewBuilder<CookReview>
    {
        public ReviewBuilder<CookReview> WithCookId(Guid cookId)
        {
            Review.CookId = cookId;
            return this;
        }
        
        public override CookReview Build()
        {
            return Review;
        }
    }
}