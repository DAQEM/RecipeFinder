namespace BLL.Data.Cook.Follower;

public interface IFollowerService
{
    List<Entities.Cook.Cook> GetForCook(Entities.Cook.Cook cook);
    void Add(Entities.Cook.Cook cook, Entities.Cook.Cook following);
    void Delete(Entities.Cook.Cook cook, Entities.Cook.Cook following);
}