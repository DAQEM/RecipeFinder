namespace BLL.Entities.Review;

public class RecipeReview : Review
{
    private readonly Guid _recipeId;

    private RecipeReview(Guid id, string comment, int rating, DateTime createdAt, Reviewer reviewer, Guid recipeId) 
        : base(id, comment, rating, createdAt, reviewer)
    {
        _recipeId = recipeId;
    }

    public class Builder : ReviewBuilder<RecipeReview>
    {
        private Guid _recipeId;
        
        public ReviewBuilder<RecipeReview> WithCookId(Guid recipeId)
        {
            _recipeId = recipeId;
            return this;
        }
        
        public override RecipeReview Build()
        {
            return new RecipeReview(Id, Comment, Rating, CreatedAt, Reviewer, _recipeId);
        }
    }
}