namespace BLL.Entities.Review;

public abstract class Review
{
    private readonly Guid _reviewerId;
    private string _comment;
    private int _rating;
    private readonly DateTime _createdAt;
    
    protected Review(Guid reviewerId, string comment, int rating, DateTime createdAt)
    {
        _reviewerId = reviewerId;
        _comment = comment;
        _rating = rating;
        _createdAt = createdAt;
    }
    
    public Guid ReviewerId => _reviewerId;
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
}