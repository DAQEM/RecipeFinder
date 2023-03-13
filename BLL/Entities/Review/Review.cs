namespace BLL.Entities.Review;

public abstract class Review
{
    private readonly Guid _id;
    private string _comment;
    private int _rating;
    private readonly DateTime _createdAt;
    
    private readonly Reviewer _reviewer;
    
    
    
    protected Review(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer)
    {
        _id = id;
        _comment = comment;
        _rating = rating;
        _createdAt = createdAt;
        _reviewer = reviewer;
    }

    public Guid Id => _id;
    public string Comment => _comment;
    public int Rating => _rating;
    public DateTime CreatedAt => _createdAt;
    
    public Reviewer Reviewer => _reviewer;
    
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
        protected Guid Id = new Guid();
        protected string Comment = string.Empty;
        protected int Rating = 0;
        protected DateTime CreatedAt = DateTime.Now;

        protected Reviewer Reviewer = Reviewer.Empty;
        
        public ReviewBuilder<T> WithId(Guid id)
        {
            Id = id;
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
        
        public ReviewBuilder<T> WithReviewer(Reviewer reviewer)
        {
            Reviewer = reviewer;
            return this;
        }

        public abstract T Build();
    }
}