using FluentAssertions;
using NSubstitute;
using System.Linq.Expressions;

namespace Application.Tests.UseCases;

public class DeleteUseCaseTest
{
    private IRepository<$ext_safeprojectname$> _repository = Substitute.For<IRepository<$ext_safeprojectname$>>();
    private DeleteUseCase<$ext_safeprojectname$> _deleteUseCase;

    public DeleteUseCaseTest()
    {
        _deleteUseCase = new DeleteUseCase<$ext_safeprojectname$>(_repository);
    }

    [Fact]
    public async Task DeleteReturnsNotFoundAsync()
    {
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        await _deleteUseCase.DeleteAsync(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        _repository.ReceivedCalls().Count().Should().Be(1);
    }

    [Fact]
    public async Task DeleteReturnsOkAsync()
    {
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var entity = new $ext_safeprojectname$();
        _repository.Find(filter).ReturnsForAnyArgs(new List<$ext_safeprojectname$>() { entity });

        await _deleteUseCase.DeleteAsync(tenantId, entityId);

        _repository.ReceivedWithAnyArgs().Find(filter);
        await _repository.ReceivedWithAnyArgs().UpdateAsync(entity);
        _repository.ReceivedCalls().Count().Should().Be(2);
    }
}