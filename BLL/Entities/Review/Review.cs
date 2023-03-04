namespace BLL.Entities.Review;

public abstract class Review
{
    private readonly Guid _id;
    private readonly string _reviewerFullname;
    private readonly string _reviewerImageUrl;
    private string _comment;
    private int _rating;
    private readonly DateTime _createdAt;
    
    protected Review(Guid id, string reviewerFullname, string reviewerImageUrl, string comment, int rating, DateTime createdAt)
    {
        _id = id;
        _reviewerFullname = reviewerFullname;
        _reviewerImageUrl = reviewerImageUrl;
        _comment = comment;
        _rating = rating;
        _createdAt = createdAt;
    }
    
    public Guid Id => _id;
    public string ReviewerFullname => _reviewerFullname;
    public string ReviewerImageUrl => _reviewerImageUrl;
    public string Comment => _comment;
    public int Rating => _rating;
    public DateTime CreatedAt => _createdAt;
    
    public void UpdateComment(string comment)
    {
        _comment = comment;
    }
    
    public void UpdateRating(int rating)
    {
        _rating = rating;
    }

    public abstract class ReviewBuilder<T>
    {
        protected Guid Id;
        protected string ReviewerFullname;
        protected string ReviewerImageUrl;
        protected string Comment;
        protected int Rating;
        protected DateTime CreatedAt;
        
        public ReviewBuilder<T> WithId(Guid id)
        {
            Id = id;
            return this;
        }
        
        public ReviewBuilder<T> WithReviewerFullname(string reviewerFullname)
        {
            ReviewerFullname = reviewerFullname;
            return this;
        }
        
        public ReviewBuilder<T> WithReviewerImageUrl(string reviewerImageUrl)
        {
            ReviewerImageUrl = reviewerImageUrl;
            return this;
        }
        
        public ReviewBuilder<T> WithComment(string comment)
        {
            Comment = comment;
            return this;
        }
        
        public ReviewBuilder<T> WithRating(int rating)
        {
            Rating = rating;
            return this;
        }
        
        public ReviewBuilder<T> WithCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
            return this;
        }

        public abstract T Build();
    }
}