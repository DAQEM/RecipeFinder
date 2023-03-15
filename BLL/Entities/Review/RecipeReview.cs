namespace BLL.Entities.Review;

public class RecipeReview : Review
{
    private Guid _recipeId;

    //For Builder only
    public RecipeReview() : base(Guid.Empty, null, 0, DateTime.Now, null)
    {
        _recipeId = Guid.Empty;
    }
    
    private RecipeReview(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer, Guid recipeId) 
        : base(id, comment, rating, createdAt, reviewer)
    {
        _recipeId = recipeId;
    }
    
    public Guid RecipeId { get => _recipeId; private set => _recipeId = value; }

    public class Builder : ReviewBuilder<RecipeReview>
    {
        public ReviewBuilder<RecipeReview> WithRecipeId(Guid recipeId)
        {
            Review._recipeId = recipeId;
            return this;
        }
        
        public override RecipeReview Build()
        {
            return Review;
        }
    }
}