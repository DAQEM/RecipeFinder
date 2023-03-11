namespace BLL.Data.Recipe.Like;

public class LikeService : ILikeService
{
    private readonly ILikeRepository _likeRepository;
    
    public LikeService(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }
}