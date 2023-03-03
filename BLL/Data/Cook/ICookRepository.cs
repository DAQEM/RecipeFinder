namespace BLL.Data.Cook;

public interface ICookRepository
{
    List<Entities.Cook.Cook> GetAll();
    Entities.Cook.Cook GetById(Guid id);
    Entities.Cook.Cook GetByUserName(string username);
    void Add(Entities.Cook.Cook cook);
    void Update(Entities.Cook.Cook cook);
    void Delete(Entities.Cook.Cook cook);
}