
using BallestLane.Business;

namespace BallestLane.UnitTests;

public class UserServiceTests
{
    [Fact]
    public async Task GetById_ValidId_ReturnsUser()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(r => r.GetById("validId")).ReturnsAsync(new User { Id = "validId", NickName = "JohnDoe" });

        var userService = new UserService(mockUserRepository.Object);

        // Act
        var result = await userService.GetById("validId");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("validId", result.Id);
        Assert.Equal("JohnDoe", result.NickName);
    }

    [Fact]
    public async Task GetAll_ReturnsListOfUsers()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(r => r.GetAll()).ReturnsAsync(new List<User>
        {
            new User { Id = "user1", NickName = "Alice" },
            new User { Id = "user2", NickName = "Bob" }
        });

        var userService = new UserService(mockUserRepository.Object);

        // Act
        var result = await userService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<User>>(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task Add_ValidUser_CallsRepositoryAdd()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var userService = new UserService(mockUserRepository.Object);

        var newUser = new User { Id = "newUserId", NickName = "NewUser" };

        // Act
        await userService.Add(newUser);

        // Assert
        mockUserRepository.Verify(r => r.Add(newUser), Times.Once);
    }

    [Fact]
    public async Task Update_ValidUser_CallsRepositoryUpdate()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var userService = new UserService(mockUserRepository.Object);

        var existingUser = new User { Id = "existingUserId", NickName = "ExistingUser" };

        // Act
        await userService.Update(existingUser);

        // Assert
        mockUserRepository.Verify(r => r.Update(existingUser), Times.Once);
    }

    [Fact]
    public async Task Delete_ValidId_CallsRepositoryDelete()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var userService = new UserService(mockUserRepository.Object);

        // Act
        await userService.Delete("deleteUserId");

        // Assert
        mockUserRepository.Verify(r => r.Delete("deleteUserId"), Times.Once);
    }
}