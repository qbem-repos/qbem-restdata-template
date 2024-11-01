using FluentAssertions;
using NSubstitute;
using System.Linq.Expressions;

namespace DomainNames.Application.Tests.UseCases;

public class DeleteDomainNameUseCaseTest
{
    private readonly IRepository<DomainName> _repository = Substitute.For<IRepository<DomainName>>();
    private readonly DeleteUseCase<DomainName> _deleteUseCase;

    public DeleteDomainNameUseCaseTest()
    {
        _deleteUseCase = new DeleteUseCase<DomainName>(_repository);
    }

    [Fact]
    public async Task DeleteReturnsNotFoundAsync()
    {
        // arrange
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<DomainName, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        // act
        await _deleteUseCase.DeleteAsync(tenantId, entityId);
        _repository.ReceivedWithAnyArgs().Find(filter);

        // assert
        _repository.ReceivedCalls().Count().Should().Be(1);
    }

    [Fact]
    public async Task DeleteReturnsOkAsync()
    {
        // arrange
        var tenantId = "Test";
        var entityId = "Test";

        Expression<Func<DomainName, bool>> filter = x => x.TenantId == tenantId
                                               && x.Id == entityId
                                               && x.DeletedAt == default;

        var entity = new DomainName();
        _repository.Find(filter).ReturnsForAnyArgs(new List<DomainName>() { entity });

        // act
        await _deleteUseCase.DeleteAsync(tenantId, entityId);
        _repository.ReceivedWithAnyArgs().Find(filter);
        await _repository.ReceivedWithAnyArgs().UpdateAsync(entity);

        // assert
        _repository.ReceivedCalls().Count().Should().Be(2);
    }
}