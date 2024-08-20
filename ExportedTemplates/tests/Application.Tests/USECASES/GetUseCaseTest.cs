using NSubstitute;
using System.Linq.Expressions;

namespace Application.Tests.UseCases;

public class GetUseCaseTest
{
    private IRepository<$ext_safeprojectname$> _repository = Substitute.For<IRepository<$ext_safeprojectname$>>();
    private GetUseCase<$ext_safeprojectname$> _getUseCase;

    public GetUseCaseTest()
    {
        _getUseCase = new GetUseCase<$ext_safeprojectname$>(_repository);
    }

    [Fact]
    public void GetReturnsNull()
    {
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == tenantId
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

        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var entities = new List<$ext_safeprojectname$>()
        {
            new $ext_safeprojectname$(),
            new $ext_safeprojectname$()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        var result = _getUseCase.Get(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        Assert.NotNull(result);
        Assert.Equal(result, entities[0]);
    }
}
