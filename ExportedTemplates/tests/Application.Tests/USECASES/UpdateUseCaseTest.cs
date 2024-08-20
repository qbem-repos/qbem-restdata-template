using NSubstitute;
using System.Linq.Expressions;

namespace Application.Tests.UseCases;

public class UpdateUseCaseTst
{
    private IRepository<$ext_safeprojectname$> _repository = Substitute.For<IRepository<$ext_safeprojectname$>>();
    private UpdateUseCase<$ext_safeprojectname$> _updateUseCase;

    public UpdateUseCaseTst()
    {
        _updateUseCase = new UpdateUseCase<$ext_safeprojectname$>(_repository);
    }

    [Fact]
    public async Task UpdateReturnsNotFoundAsync()
    {
        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;

        var result = await _updateUseCase.UpdateAsync(new $ext_safeprojectname$(), filter);

        _repository.Received(1).Find(filter);
        await _repository.Received(0).UpdateAsync(new $ext_safeprojectname$());
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateReturnsEntityOk()
    {
        Expression<Func<$ext_safeprojectname$, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;
        var entities = new List<$ext_safeprojectname$>()
        {
            new $ext_safeprojectname$(),
            new $ext_safeprojectname$()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        var result = await _updateUseCase.UpdateAsync(new $ext_safeprojectname$(), filter);

        _repository.Received(1).Find(filter);
        await _repository.ReceivedWithAnyArgs(1).UpdateAsync(new $ext_safeprojectname$());
        Assert.NotNull(result);
    }
}