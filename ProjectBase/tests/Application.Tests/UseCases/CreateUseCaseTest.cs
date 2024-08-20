using NSubstitute;

namespace Application.Tests.UseCases;

public class CreateUseCaseTest
{
    private IRepository<MyEntity> _repository = Substitute.For<IRepository<MyEntity>>();
    private CreateUseCase<MyEntity> _createUseCase;

    public CreateUseCaseTest()
    {
        _createUseCase = new CreateUseCase<MyEntity>(_repository);
    }

    [Fact]
    public async Task CreateReturnsOk()
    {
        var entity = new MyEntity()
        {
            TenantId = Guid.NewGuid().ToString()
        };

        await _createUseCase.CreateAsync(entity);
        await _repository.Received(1).CreateAsync(entity);
        Assert.NotNull(entity.Id);
    }
}