namespace GymGestor.Core.ValueObjects
{
    public sealed class Address
    {
        public string Street { get; }
        public string Number { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        public Address(string street, string number, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        // Implementação de igualdade baseada nos valores
        public override bool Equals(object? obj)
        {
            if (obj is not Address other) return false;
            return Street == other.Street &&
                   Number == other.Number &&
                   City == other.City &&
                   State == other.State &&
                   ZipCode == other.ZipCode;
        }

        public override int GetHashCode() => HashCode.Combine(Street, Number, City, State, ZipCode);
    }
}
