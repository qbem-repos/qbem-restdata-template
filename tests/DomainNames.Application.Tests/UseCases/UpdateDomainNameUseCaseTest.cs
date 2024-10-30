using NSubstitute;
using System.Linq.Expressions;

namespace DomainNames.Application.Tests.UseCases;

public class UpdateDomainNameUseCaseTest
{
    private readonly IRepository<DomainName> _repository = Substitute.For<IRepository<DomainName>>();
    private readonly UpdateUseCase<DomainName> _updateUseCase;

    public UpdateDomainNameUseCaseTest()
    {
        _updateUseCase = new UpdateUseCase<DomainName>(_repository);
    }

    [Fact]
    public async Task UpdateReturnsNotFoundAsync()
    {
        // arrange
        Expression<Func<DomainName, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;

        // act
        var result = await _updateUseCase.UpdateAsync(new DomainName(), filter);

        _repository.Received(1).Find(filter);
        await _repository.Received(0).UpdateAsync(new DomainName());
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateReturnsEntityOk()
    {
        // arrange
        Expression<Func<DomainName, bool>> filter = x => x.TenantId == "Test"
                                               && x.Id == "Test"
                                               && x.DeletedAt == default;
        var entities = new List<DomainName>()
        {
            new DomainName(),
            new DomainName()
        };

        _repository.Find(filter).ReturnsForAnyArgs(entities);

        // act
        var result = await _updateUseCase.UpdateAsync(new DomainName(), filter);

        _repository.Received(1).Find(filter);
        await _repository.ReceivedWithAnyArgs(1).UpdateAsync(new DomainName());

        // assert
        Assert.NotNull(result);
    }
}