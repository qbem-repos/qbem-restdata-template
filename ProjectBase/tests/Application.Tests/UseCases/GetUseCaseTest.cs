using NSubstitute;
using System.Linq.Expressions;

namespace Application.Tests.UseCases;

public class GetUseCaseTest
{
    private IRepository<MyEntity> _repository = Substitute.For<IRepository<MyEntity>>();
    private GetUseCase<MyEntity> _getUseCase;

    public GetUseCaseTest()
    {
        _getUseCase = new GetUseCase<MyEntity>(_repository);
    }

    [Fact]
    public void GetReturnsNull()
    {
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<MyEntity, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var result = _getUseCase.Get(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        Assert.Null(result);
    }

    [Fact]
    public void GetReturnsEntityFounded()
    {
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<MyEntity, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var entities = new List<MyEntity>()
        {
            new MyEntity(),
            new MyEntity()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        var result = _getUseCase.Get(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        Assert.NotNull(result);
        Assert.Equal(result, entities[0]);
    }
}
