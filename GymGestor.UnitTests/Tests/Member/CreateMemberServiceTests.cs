using GymGestor.Application.Services.Member.Create;
using GymGestor.Core.Exceptions;
using GymGestor.Core.Repositories;
using GymGestor.Infra.Persistence.UnityOfWork;
using GymGestor.UnitTests.Builders.Member;
using Moq;

namespace GymGestor.UnitTests.Tests.Member;
public class CreateMemberServiceTests
{
    private readonly Mock<IUnityOfWork> _mockUnitOfWork;
    private readonly Mock<IMemberRepository> _mockMemberRepository;
    private readonly Mock<CreateMemberService> _service;

    public CreateMemberServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnityOfWork>();
        _mockMemberRepository = new Mock<IMemberRepository>();

        _mockUnitOfWork.Setup(uow => uow.Members).Returns(_mockMemberRepository.Object);

        _service = new Mock<CreateMemberService>(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Create_ShouldAddMemberAndComplete_WhenModelIsValid()
    {
        //Arrange
        var model = CreateMemberInputModelBuilder.BuildValid();

        //Act
        await _service.Object.Create(model);

        // Assert
        _mockMemberRepository.Verify(repo => repo.Add(It.IsAny<Core.Entities.Member>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task Create_ShouldThrow_WhenGenderIsInvalid()
    {
        // Arrange
        var model = CreateMemberInputModelBuilder.WithInvalidGender();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.Object.Create(model));
    }

    [Fact]
    public async Task Create_ShouldThrow_WhenCpfIsInvalid()
    {
        // Arrange
        var model = CreateMemberInputModelBuilder.WithInvalidCpf();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.Object.Create(model));
    }

    [Fact]
    public async Task Create_ShouldThrow_WhenEmailIsInvalid()
    {
        // Arrange
        var model = CreateMemberInputModelBuilder.WithInvalidEmail();

        // Act & Assert
        await Assert.ThrowsAsync<ValidationErrorsException>(() => _service.Object.Create(model));
    }
}
