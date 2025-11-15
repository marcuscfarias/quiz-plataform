using System.Runtime.CompilerServices;
using Application.Users.Contracts;
using Application.Users.Services;
using Domain.Entities;
using Domain.Repositories;
using Xunit.Sdk;

namespace UnitTests.Application.UserServiceTests;

public class CreateUserTests
{
    //MethodName_StateUnderTest_ExpectedBehavior
    [Fact]
    public async Task CreateUserAsync_UserExists_ShouldThrowException()
    {
        //arrange
        var request = RequestFaker().Generate();
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.HasUserByEmailAsync(request.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var userService = new UserService(mockUserRepository.Object);

        //act
        var act = () => userService.CreateUserAsync(request, It.IsAny<CancellationToken>());

        //assert
        await Assert.ThrowsAsync<ApplicationException>(act);
        mockUserRepository
            .Verify(x => x.HasUserByEmailAsync(request.Email, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task CreateUserAsync_UserDoesNotExist_ShouldReturnId()
    {
        //arrange
        int randomId = new Random().Next(1, int.MaxValue);
        var request = RequestFaker().Generate();
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(randomId);

        var userService = new UserService(mockUserRepository.Object);

        //act
        var result = await userService.CreateUserAsync(request, CancellationToken.None);

        //assert
        Assert.Equal(randomId, result);
        mockUserRepository
            .Verify(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    private static Faker<CreateUserRequest> RequestFaker()
    {
        return new Faker<CreateUserRequest>("en")
            .CustomInstantiator(f => new CreateUserRequest(
                f.Name.FullName(),
                f.Internet.Password(),
                f.Internet.Email(),
                f.Date.PastDateOnly(18)));
    }
}