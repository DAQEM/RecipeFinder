﻿using BLL.Data.Review;
using BLL.Entities.Review;

namespace DAL.Repositories;

public class RecipeReviewRepository : IRecipeReviewRepository
{
    public List<RecipeReview> GetAll()
    {
        throw new NotImplementedException();
    }

    public RecipeReview GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<RecipeReview> GetByCookId(Guid cookId)
    {
        throw new NotImplementedException();
    }

    public List<RecipeReview> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(RecipeReview review)
    {
        throw new NotImplementedException();
    }

    public void Update(RecipeReview review)
    {
        throw new NotImplementedException();
    }

    public void Delete(RecipeReview review)
    {
        throw new NotImplementedException();
    }

    public RecipeReview GetForRecipeId(Guid recipeId)
    {
        throw new NotImplementedException();
    }
}