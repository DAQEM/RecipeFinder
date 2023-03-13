﻿using BLL.Entities.Review;

namespace BLL.Data.Cook;

public interface ICookService
{
    List<Entities.Cook.Cook> GetAll();
    Entities.Cook.Cook? GetById(Guid id);
    Entities.Cook.Cook? GetByUserName(string username);
    void Add(Entities.Cook.Cook cook);
    void Update(Entities.Cook.Cook cook);
    void Delete(string username);
    List<Entities.Recipe.Recipe> GetRecipesByUsername(string username);
    List<CookReview> GetReviewsForUsername(string username);
}