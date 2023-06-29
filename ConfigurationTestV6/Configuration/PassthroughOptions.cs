namespace ConfigurationTestV6.Configuration;

public class PassthroughOptions
{
    public static List<string> EmptyList = new();
    public static List<string> DefaultList = new() { "Default1", "Default2", "Duplicate" };
    public ICollection<string>? ICollection { get; set; }

    public ICollection<string> ICollectionEmpty {get;set;} = EmptyList;

    public ICollection<string> ICollectionDefault {get; set;} = DefaultList;

    public IReadOnlyCollection<string>? IReadOnlyCollection { get; set; }

    public IReadOnlyCollection<string> IReadOnlyCollectionEmpty {get; set;} = EmptyList;

    public IReadOnlyCollection<string> IReadonlyCollectionDefault {get; set;} = DefaultList;

}
