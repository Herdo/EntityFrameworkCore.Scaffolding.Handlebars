namespace Scaffolding.Handlebars.Tests.Models
{
    public struct EmployeeId
    {
        private readonly int _value;

        private EmployeeId(int value)
        {
            _value = value;
        }

        public static explicit operator EmployeeId(int s) => new(s);

        public static explicit operator int(EmployeeId t) => t._value;
    }
}