namespace BLL.Data.Cook;

public interface ICookRepository
{
    List<Entities.Cook> GetAll();
    Entities.Cook GetById(Guid id);
    void Add(Entities.Cook cook);
    void Update(Entities.Cook cook);
    void Delete(Entities.Cook cook);
}