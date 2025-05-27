using System.Text.RegularExpressions;

namespace GymGestor.Core.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }

        private Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O e-mail não pode ser vazio.");

            if (!IsValidEmail(value))
                throw new ArgumentException("E-mail inválido.");

            Value = value;
        }

        public static Email Create(string value) => new Email(value);

        private static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
            return emailRegex.IsMatch(email);
        }

        public override string ToString() => Value;

        public override bool Equals(object? obj)
        {
            if (obj is Email other)
                return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);

        public static bool operator ==(Email a, Email b) => a?.Equals(b) ?? b is null;
        public static bool operator !=(Email a, Email b) => !(a == b);
    }
}
