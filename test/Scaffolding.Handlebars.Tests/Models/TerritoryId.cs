namespace Scaffolding.Handlebars.Tests.Models
{
    public struct TerritoryId
    {
        private readonly string _value;

        private TerritoryId(string value)
        {
            _value = value;
        }

        public static explicit operator TerritoryId(string s) => new(s);

        public static explicit operator string(TerritoryId t) => t._value;
    }
}