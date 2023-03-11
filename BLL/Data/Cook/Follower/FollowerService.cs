namespace BLL.Data.Cook.Follower;

public class FollowerService : IFollowerService
{
    private readonly IFollowerRepository _followerRepository;
    
    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }
}