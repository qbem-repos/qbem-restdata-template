using NSubstitute;

namespace Application.Tests.UseCases;

public class CreateUseCaseTest
{
    private IRepository<$ext_safeprojectname$> _repository = Substitute.For<IRepository<$ext_safeprojectname$>>();
    private CreateUseCase<$ext_safeprojectname$> _createUseCase;

    public CreateUseCaseTest()
    {
        _createUseCase = new CreateUseCase<$ext_safeprojectname$>(_repository);
    }

    [Fact]
    public async Task CreateReturnsOk()
    {
        var entity = new $ext_safeprojectname$()
        {
            TenantId = Guid.NewGuid().ToString()
        };

        await _createUseCase.CreateAsync(entity);
        await _repository.Received(1).CreateAsync(entity);
        Assert.NotNull(entity.Id);
    }
}