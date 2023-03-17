namespace BLL.Data.Cook.Follower;

public interface IFollowerRepository
{
    List<Entities.Cook.Cook> GetForCookId(Guid cookId);
    void Add(Guid cookId, Guid followingId);
    void Delete(Guid cookId, Guid followingId);
}