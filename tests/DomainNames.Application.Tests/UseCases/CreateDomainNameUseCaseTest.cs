using NSubstitute;

namespace DomainNames.Application.Tests.UseCases;

public class CreateDomainNameUseCaseTest
{
    private readonly IRepository<DomainName> _repository = Substitute.For<IRepository<DomainName>>();
    private readonly CreateUseCase<DomainName> _createUseCase;

    public CreateDomainNameUseCaseTest()
    {
        _createUseCase = new CreateUseCase<DomainName>(_repository);
    }

    [Fact]
    public async Task CreateReturnsOk()
    {
        // arrange
        var entity = new DomainName()
        {
            TenantId = Guid.NewGuid().ToString()
        };

        // act
        await _createUseCase.CreateAsync(entity);
        await _repository.Received(1).CreateAsync(entity);

        // assert
        Assert.NotNull(entity.Id);
    }
}