using BLL.Data.Cook;
using BLL.Data.Cook.Credential;
using BLL.Data.Cook.Follower;
using BLL.Data.Recipe;
using BLL.Data.Review;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Exceptions;
using Moq;

namespace BLL.Tests.ServiceTests;

[TestFixture]
public class CookServiceTests
{
    private Mock<ICookRepository> _mockCookRepo;
    private Mock<ICredentialService> _mockCredService;
    private Mock<IRecipeService> _mockRecipeService;
    private Mock<ICookReviewService> _mockCookReviewService;
    private Mock<IFollowerService> _mockFollowerService;
    private CookService _cookService;

    [SetUp]
    public void SetUp()
    {
        _mockCookRepo = new Mock<ICookRepository>();
        _mockCredService = new Mock<ICredentialService>();
        _mockRecipeService = new Mock<IRecipeService>();
        _mockCookReviewService = new Mock<ICookReviewService>();
        _mockFollowerService = new Mock<IFollowerService>();
        _cookService = new CookService(_mockCookRepo.Object, _mockCredService.Object,
            _mockRecipeService.Object, _mockCookReviewService.Object, _mockFollowerService.Object);
    }

    [Test]
    public void GetAll_ShouldReturnListOfCooks()
    {
        // Arrange
        List<Cook> expectedCooks = new() { new Cook(), new Cook() };
        _mockCookRepo.Setup(repo => repo.GetAll()).Returns(expectedCooks);

        // Act
        List<Cook> actualCooks = _cookService.GetAll();

        // Assert
        Assert.That(actualCooks, Is.EqualTo(expectedCooks));
    }

    [Test]
    public void GetById_WhenCookExists_ShouldReturnCook()
    {
        // Arrange
        Guid cookId = Guid.NewGuid();
        Cook expectedCook = new(id: cookId);
        _mockCookRepo.Setup(repo => repo.GetById(cookId)).Returns(expectedCook);

        // Act
        Cook actualCook = _cookService.GetById(cookId);

        // Assert
        Assert.That(actualCook, Is.EqualTo(expectedCook));
    }

    [Test]
    public void GetById_WhenCookDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        Guid cookId = Guid.NewGuid();
        _mockCookRepo.Setup(repo => repo.GetById(cookId)).Returns((Cook)null);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => _cookService.GetById(cookId));
    }

    [Test]
    public void GetByUsername_WhenCookExists_ShouldReturnCook()
    {
        // Arrange
        const string username = "Kevin";
        Cook expectedCook = new(username: username);
        _mockCookRepo.Setup(repo => repo.GetByUserName(username)).Returns(expectedCook);

        // Act
        Cook actualCook = _cookService.GetByUsername(username);

        // Assert
        Assert.That(actualCook, Is.EqualTo(expectedCook));
    }

    [Test]
    public void GetByUsername_WhenCookDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        const string username = "Kevin";
        _mockCookRepo.Setup(repo => repo.GetByUserName(username)).Returns((Cook)null);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => _cookService.GetByUsername(username));
    }
    
    [Test]
    public void Add_InvokesCookRepositoryAdd()
    {
        // Arrange
        Cook cook = new();

        // Act
        _cookService.Add(cook);

        // Assert
        _mockCookRepo.Verify(x => x.Add(cook), Times.Once);
    }

    [Test]
    public void Update_InvokesCookRepositoryUpdate()
    {
        // Arrange
        Cook cook = new();

        // Act
        _cookService.Update(cook);

        // Assert
        _mockCookRepo.Verify(x => x.Update(cook), Times.Once);
    }

    [Test]
    public void UpdateWithCredentials_InvokesCookRepositoryUpdateAndCredentialServiceUpdate()
    {
        // Arrange
        Cook cook = new();
        Credential credential = new();
        cook.SetCredential(credential);

        // Act
        _cookService.UpdateWithCredentials(cook);

        // Assert
        _mockCookRepo.Verify(x => x.Update(cook), Times.Once);
        _mockCredService.Verify(x => x.Update(cook.Credential), Times.Once);
    }

    [Test]
    public void Delete_InvokesCookRepositoryDelete()
    {
        // Arrange
        const string username = "Kevin";

        // Act
        _cookService.Delete(username);

        // Assert
        _mockCookRepo.Verify(x => x.Delete(username), Times.Once);
    }

    [TestCase("Kevin", 2, 0)]
    [TestCase("Henk", 0, 2)]
    [TestCase("Jan", 2, 2)]
    public void GetByUsernameWithRecipes_ShouldReturnCookWithRecipes(string username, int cookRecipes, int nonCookRecipes)
    {
        // Arrange
        Guid cookId = Guid.NewGuid();
        Cook cook = new(id: cookId, username: username);
        List<Recipe> recipes = new();
        
        for (int i = 0; i < cookRecipes; i++)
        {
            recipes.Add(new Recipe(cookId: cookId));
        }
        
        for (int i = 0; i < nonCookRecipes; i++)
        {
            recipes.Add(new Recipe());
        }
        
        _mockCookRepo.Setup(r => r.GetByUserName(username)).Returns(cook);
        _mockRecipeService.Setup(s => s.GetByCookIdWithReviews(cookId)).Returns(recipes.Where(r => r.CookId == cookId).ToList());

        // Act
        Cook result = _cookService.GetByUsernameWithRecipes(username);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(cook));
        Assert.That(result.Recipes.Count, Is.EqualTo(cookRecipes));
    }
    
    [Test]
    public void GetByUsernameWithCredentials_ShouldReturnCookWithCredential()
    {
        // Arrange
        const string username = "Kevin";
        Guid cookId = Guid.NewGuid();
        Credential credential = new(cookId: cookId);
        Cook cook = new(id: cookId, username: username);
        _mockCookRepo.Setup(r => r.GetByUserName(username)).Returns(cook);
        _mockCredService.Setup(s => s.GetByCookId(cookId)).Returns(credential);

        // Act
        Cook result = _cookService.GetByUsernameWithCredentials(username);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(cook));
        Assert.That(result.Credential, Is.EqualTo(credential));
    }
}