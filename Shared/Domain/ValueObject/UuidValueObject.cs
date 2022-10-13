using System.ComponentModel;

namespace Shared.Domain.ValueObject
{
    public class UuidValueObject : ValueObject
    {
        public string Value { get; }

        public UuidValueObject(string value)
        {
            EnsureIsValidUuid(value);
            Value = value;
        }

        private void EnsureIsValidUuid(string value)
        {
            if (!Guid.TryParse(value, out var Uuid))
                throw new InvalidEnumArgumentException($"{value} is not a valid GUID");
        }

        public override string ToString()
        {
            return Value;
        }

        public static UuidValueObject Random()
        {
            return new UuidValueObject(Guid.NewGuid().ToString());
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as UuidValueObject;
            if (item == null) return false;

            return Value == item.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
