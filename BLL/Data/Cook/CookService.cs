namespace BLL.Data.Cook;

public class CookService
{
    private readonly ICookRepository _cookRepository;

    public CookService(ICookRepository cookRepository)
    {
        _cookRepository = cookRepository;
    }
    
    public List<Entities.Cook> GetAll()
    {
        return _cookRepository.GetAll();
    }
    
    public Entities.Cook GetById(Guid id)
    {
        return _cookRepository.GetById(id);
    }
    
    public void Add(Entities.Cook cook)
    {
        _cookRepository.Add(cook);
    }
    
    public void Update(Entities.Cook cook)
    {
        _cookRepository.Update(cook);
    }
    
    public void Delete(Entities.Cook cook)
    {
        _cookRepository.Delete(cook);
    }
}