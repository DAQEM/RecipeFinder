namespace BLL.Entities.Review;

public abstract class Review
{
    private Guid _id;
    private string _comment;
    private int _rating;
    private DateTime _createdAt;
    
    private Reviewer _reviewer;
    
    protected Review(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer)
    {
        _id = id;
        _comment = comment;
        _rating = rating;
        _createdAt = createdAt;
        _reviewer = reviewer;
    }

    public Guid Id { get => _id; protected set => _id = value; }
    public string Comment { get => _comment; protected set => _comment = value; }
    public int Rating { get => _rating; protected set => _rating = value; }
    public DateTime CreatedAt { get => _createdAt; protected set => _createdAt = value; }
    
    public Reviewer Reviewer { get => _reviewer; protected set => _reviewer = value; }
    
    public abstract class ReviewBuilder<T> where T : Review
    {
        protected readonly T Review = (T)Activator.CreateInstance(typeof(T))!;
        
        public ReviewBuilder<T> WithId(Guid id)
        {
            Review.Id = id;
            return this;
        }

        public ReviewBuilder<T> WithComment(string comment)
        {
            Review.Comment = comment;
            return this;
        }
        
        public ReviewBuilder<T> WithRating(int rating)
        {
            Review.Rating = rating;
            return this;
        }
        
        public ReviewBuilder<T> WithCreatedAt(DateTime createdAt)
        {
            Review.CreatedAt = createdAt;
            return this;
        }
        
        public ReviewBuilder<T> WithReviewer(Reviewer reviewer)
        {
            Review.Reviewer = reviewer;
            return this;
        }

        public abstract T Build();
    }
}