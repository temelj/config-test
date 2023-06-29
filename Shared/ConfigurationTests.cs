using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FluentAssertions;
using Shared;

namespace Test;

public class ConfigurationTests
{
    [Fact]
    public void Test_Defaults()
    {
        // arrange
        ServiceProvider services = RegistrationHelper.BuildProvider(TestDataHelper.DefaultConfig);

        // act
        var options = services.GetService<IOptions<PassthroughOptions>>()?.Value;

        // assert
        Assert.NotNull(options);

        options.Headers.Should().NotBeEmpty();
        options.Headers.Should().Contain("CorrelationId");
        //options.ICollectionEmpty.Should().BeEmpty();
        //options.ICollectionDefault.Should().NotBeNullOrEmpty();
        //options.ICollectionDefault.Should().HaveCount(PassthroughOptions.DefaultList.Count);
    }

    [Fact]
    public void Test_FromConfiguration()
    {
        // arrange
        ServiceProvider services = RegistrationHelper.BuildProvider(TestDataHelper.CustomConfig);

        // act
        var options = services.GetService<IOptions<PassthroughOptions>>()?.Value;

        // assert
        Assert.NotNull(options);

        options.Headers.Should().HaveCount(3);
        options.Headers.Should().Contain("CorrelationId");

        //options.ICollection.Should().NotBeNullOrEmpty();
        //options.ICollection.Should().HaveCount(5);

        //options.ICollectionEmpty.Should().NotBeNullOrEmpty();
        //options.ICollectionEmpty.Should().HaveCount(TestDataHelper.CustomList.Count);
        //options.ICollectionEmpty.Should().Equal(TestDataHelper.CustomList);

        //options.ICollectionDefault.Should().NotBeNullOrEmpty();

        // this combined list contains the "Duplicate" two times
        //var combinedList = PassthroughOptions.DefaultList;
        //combinedList.AddRange(TestDataHelper.CustomList);
        //options.ICollectionDefault.Should().Equal(combinedList);
        //options.ICollectionDefault.Should().HaveCount(8);
    }
}