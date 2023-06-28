using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TestProject1.Configuration;
using FluentAssertions;

namespace TestProject1;

public class UnitTest1
{
    private const string _custom1 = "Custom1";
    private const string _custom2 = "Custom2";
    private const string _custom3 = "Custom3";
    private const string _custom4 = "Custom4";

    public static List<string> CustomList = new() { _custom1, _custom2, _custom3, _custom4};

    public static readonly Dictionary<string, string> DefaultConfig = new()
    {
    };

    public static readonly Dictionary<string, string> CustomConfig = new()
    {
        { "PassthroughOptions:ICollection:0", _custom1 },
        { "PassthroughOptions:ICollection:1", _custom2 },
        { "PassthroughOptions:ICollection:2", _custom3 },
        { "PassthroughOptions:ICollection:3", _custom4 },
        { "PassthroughOptions:ICollectionEmpty:0", _custom1 },
        { "PassthroughOptions:ICollectionEmpty:1", _custom2 },
        { "PassthroughOptions:ICollectionEmpty:2", _custom3 },
        { "PassthroughOptions:ICollectionEmpty:3", _custom4 },
        { "PassthroughOptions:ICollectionDefault:0", _custom1 },
        { "PassthroughOptions:ICollectionDefault:1", _custom2 },
        { "PassthroughOptions:ICollectionDefault:2", _custom3 },
        { "PassthroughOptions:ICollectionDefault:3", _custom4 },
    };


    [Fact]
    public void Test_Defaults()
    {
        // arrange
        ServiceProvider services = RegistrationHelper.BuildProvider(DefaultConfig);

        // act
        var options = services.GetService<IOptions<PassthroughOptions>>()?.Value;

        // assert
        Assert.NotNull(options);

        options.ICollection.Should().BeNull();
        options.ICollectionEmpty.Should().BeEmpty();
        options.ICollectionDefault.Should().NotBeNullOrEmpty();
        options.ICollectionDefault.Should().HaveCount(PassthroughOptions.DefaultList.Count);
    }

    [Fact]
    public void Test_FromConfiguration()
    {
        // arrange
        ServiceProvider services = RegistrationHelper.BuildProvider(CustomConfig);

        // act
        var options = services.GetService<IOptions<PassthroughOptions>>()?.Value;

        // assert
        Assert.NotNull(options);

        options.ICollection.Should().NotBeNullOrEmpty();
        options.ICollection.Should().HaveCount(4);

        options.ICollectionEmpty.Should().NotBeNullOrEmpty();
        options.ICollectionEmpty.Should().HaveCount(CustomList.Count);
        options.ICollectionEmpty.Should().Equal(CustomList);

        options.ICollectionDefault.Should().NotBeNullOrEmpty();
        options.ICollectionDefault.Should().HaveCount(CustomList.Count + PassthroughOptions.DefaultList.Count);
        options.ICollectionDefault.Should().Contain(CustomList);
        options.ICollectionDefault.Should().Contain(PassthroughOptions.DefaultList);
    }
}