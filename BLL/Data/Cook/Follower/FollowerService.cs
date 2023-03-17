namespace BLL.Data.Cook.Follower;

public class FollowerService : IFollowerService
{
    private readonly IFollowerRepository _followerRepository;
    
    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }
    
    public List<Entities.Cook.Cook> GetForCook(Entities.Cook.Cook cook)
    {
        return _followerRepository.GetForCookId(cook.Id);
    }

    public void Add(Entities.Cook.Cook cook, Entities.Cook.Cook following)
    {
        _followerRepository.Add(cook.Id, following.Id);
    }

    public void Delete(Entities.Cook.Cook cook, Entities.Cook.Cook following)
    {
        _followerRepository.Delete(cook.Id, following.Id);
    }
}