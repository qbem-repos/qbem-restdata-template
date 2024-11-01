using NSubstitute;
using System.Linq.Expressions;

namespace DomainNames.Application.Tests.UseCases;

public class GetDomainNameUseCaseTest
{
    private readonly IRepository<DomainName> _repository = Substitute.For<IRepository<DomainName>>();
    private readonly GetUseCase<DomainName> _getUseCase;

    public GetDomainNameUseCaseTest()
    {
        _getUseCase = new GetUseCase<DomainName>(_repository);
    }

    [Fact]
    public void GetReturnsNull()
    {
        // arrange
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<DomainName, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        // act
        var result = _getUseCase.Get(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        Assert.Null(result);
    }

    [Fact]
    public void GetReturnsEntityFounded()
    {
        // arrange
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<DomainName, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var entities = new List<DomainName>()
        {
            new DomainName(),
            new DomainName()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        // act
        var result = _getUseCase.Get(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);

        // assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(result, entities[0]);
        });
    }
}
