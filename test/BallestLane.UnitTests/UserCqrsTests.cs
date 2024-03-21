
using Ballastlane.Domain.Abstractions;
using Ballastlane.Domain.Repositories;
using BallestLane.Business.Users.Queries.GetById;


namespace BallestLane.UnitTests;

public class UserCqrsTests
{

    [Fact]
    public async Task GetById_ValidId_ReturnsUser()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(r => r.GetById("validId")).ReturnsAsync(new User { Id = "validId", Nickname = "JohnDoe" });

        var getUserQueryHandler = new GetUserQueryHandler(mockUserRepository.Object);
        var userQueries = new UserQueries(getUserQueryHandler);

        // Act
        var result = await userQueries.GetById(new GetUserByIdQuery("validId"), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("validId", result.Id);
        Assert.Equal("JohnDoe", result.Nickname);
    }

    // [Fact]
    // public async Task GetAll_ReturnsListOfUsers()
    // {
    //     // Arrange
    //     var mockUserRepository = new Mock<IUserRepository>();
    //     mockUserRepository.Setup(r => r.GetAll()).ReturnsAsync(new List<User>
    //     {
    //         new User { Id = "user1", Nickname = "Alice" },
    //         new User { Id = "user2", Nickname = "Bob" }
    //     });

    //     var userService = new UserService(mockUserRepository.Object, (new Mock<INftRepository>()).Object);

    //     // Act
    //     var result = await userService.GetAll();

    //     // Assert
    //     Assert.NotNull(result);
    //     Assert.IsType<List<User>>(result);
    //     Assert.Equal(2, result.Count());
    // }

    [Fact]
    public async Task Add_ValidUser_CallsRepositoryAdd()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        IUserCommands userCommands = BuildUserCommands(mockUserRepository.Object);
        var newUser = new CreateUserCommand ("newUserId", "NewUser", null);

        // Act
        await userCommands.Send(newUser, CancellationToken.None);

        // Assert
        mockUserRepository.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task Update_ValidUser_CallsRepositoryUpdate()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        IUserCommands userCommands = BuildUserCommands(mockUserRepository.Object);
        var updateCommand = new UpdateUserCommand ("existingUserId", "ExistingUser", null);

        // Act
        await userCommands.Send(updateCommand, CancellationToken.None);

        // Assert
        mockUserRepository.Verify(r => r.Update(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task Delete_ValidId_CallsRepositoryDelete()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        IUserCommands userCommands = BuildUserCommands(mockUserRepository.Object);
        var deleteCommand = new DeleteUserCommand ("deleteUserId");

        // Act
        await userCommands.Send(deleteCommand, CancellationToken.None);

        // Assert
        mockUserRepository.Verify(r => r.Delete("deleteUserId"), Times.Once);
    }

    private IUserCommands BuildUserCommands(IUserRepository userRepository)
    {
        IDbUnitOfWork unitOfWork = new Mock<IDbUnitOfWork>().Object;
        return new UserCommands(new(userRepository, unitOfWork), new(userRepository, unitOfWork), new(userRepository, unitOfWork));
    }
}