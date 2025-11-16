using Application.Users.Contracts;
using Application.Users.Services;
using Domain.Entities;
using Domain.Repositories;

namespace UnitTests.Application.UserServiceTests;

public class GetUserById
{
    //MethodName_StateUnderTest_ExpectedBehavior
    [Fact]
    public async Task GetUserByIdAsync_InvalidUserId_ShouldThrowException()
    {
        //arrange
        int randomId = new Random().Next(1, Int32.MaxValue);

        var mockRepository = new Mock<IUserRepository>();
        mockRepository
            .Setup(x => x.GetByIdAsync(randomId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(null as User);

        var service = new UserService(mockRepository.Object);

        //act
        var act = () => service.GetUserByIdAsync(randomId, It.IsAny<CancellationToken>());

        //assert
        await Assert.ThrowsAsync<ApplicationException>(act);
        mockRepository.Verify(x => x.GetByIdAsync(randomId, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetUserByIdAsync_ValidUserId_ShouldReturnUserResponse()
    {
        //arrange
        int randomId = new Random().Next(1, Int32.MaxValue);
        var user = UserFaker().Generate();

        var mockRepository = new Mock<IUserRepository>();
        mockRepository
            .Setup(x => x.GetByIdAsync(randomId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var service = new UserService(mockRepository.Object);
        //act
        var result = await service.GetUserByIdAsync(randomId, It.IsAny<CancellationToken>());
        
        //assert
        Assert.NotNull(result);
        Assert.Equal(user.Username, result.Username);
        Assert.Equal(user.Email, result.Email);
        Assert.Equal(user.BirthDate, result.BirthDate);
    }

    private static Faker<User> UserFaker()
    {
        return new Faker<User>("en")
            .CustomInstantiator(f => new User(
                f.Person.FullName,
                f.Internet.Password(),
                f.Internet.Email(),
                f.Date.PastDateOnly(18),
                true));
    }
}