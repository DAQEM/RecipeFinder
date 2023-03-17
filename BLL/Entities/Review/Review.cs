namespace BLL.Entities.Review;

public class Review
{
    private Guid _id;
    private string _comment;
    private int _rating;
    private DateTime _createdAt;
    
    private Cook.Cook _reviewer;
    
    public Review(Guid? id = null, string comment = "", int rating = 0, DateTime? createdAt = null, Cook.Cook? reviewer = null)
    {
        _id = id ?? Guid.Empty;
        _comment = comment;
        _rating = rating;
        _createdAt = createdAt ?? DateTime.MinValue;
        _reviewer = reviewer ?? new Cook.Cook();
    }

    public Guid Id { get => _id; protected set => _id = value; }
    public string Comment { get => _comment; protected set => _comment = value; }
    public int Rating { get => _rating; protected set => _rating = value; }
    public DateTime CreatedAt { get => _createdAt; protected set => _createdAt = value; }
    
    public Cook.Cook Reviewer { get => _reviewer; protected set => _reviewer = value; }
}