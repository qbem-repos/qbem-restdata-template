using NSubstitute;
using System.Linq.Expressions;

namespace Application.Tests.UseCases;

public class UpdateUseCaseTst
{
    private IRepository<MyEntity> _repository = Substitute.For<IRepository<MyEntity>>();
    private UpdateUseCase<MyEntity> _updateUseCase;

    public UpdateUseCaseTst()
    {
        _updateUseCase = new UpdateUseCase<MyEntity>(_repository);
    }

    [Fact]
    public async Task UpdateReturnsNotFoundAsync()
    {
        Expression<Func<MyEntity, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;

        var result = await _updateUseCase.UpdateAsync(new MyEntity(), filter);

        _repository.Received(1).Find(filter);
        await _repository.Received(0).UpdateAsync(new MyEntity());
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateReturnsEntityOk()
    {
        Expression<Func<MyEntity, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;
        var entities = new List<MyEntity>()
        {
            new MyEntity(),
            new MyEntity()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        var result = await _updateUseCase.UpdateAsync(new MyEntity(), filter);

        _repository.Received(1).Find(filter);
        await _repository.ReceivedWithAnyArgs(1).UpdateAsync(new MyEntity());
        Assert.NotNull(result);
    }
}