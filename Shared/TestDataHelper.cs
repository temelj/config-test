namespace Shared
{
    public static class TestDataHelper
    {
        private const string _custom1 = "Custom1";
        private const string _custom2 = "Custom2";
        private const string _custom3 = "Custom3";
        private const string _custom4 = "Custom4";
        private const string _duplicate = "CorrelationId";

        public static List<string> CustomList = new() { _custom1, _custom2, _custom3, _custom4, _duplicate };

        public static readonly Dictionary<string, string> DefaultConfig = new()
        {
        };

        public static readonly Dictionary<string, string> CustomConfig = new()
        {
            { "Base:PassthroughOptions:Headers:0", _duplicate },
            { "Base:PassthroughOptions:Headers:1", _custom1 },
            { "Base:PassthroughOptions:Headers:2",  _custom2 }
        };
    }
}
