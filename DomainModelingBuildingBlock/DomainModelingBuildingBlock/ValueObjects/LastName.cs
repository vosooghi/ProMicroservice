namespace DomainModelingBuildingBlock.ValueObjects
{
    public class LastName
    {
        public string Value { get; private set; }

        public LastName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            Value = value;
        }

        public LastName SetLastName(string value)
        {
            return new LastName(value);
        }

        //these methods are repeated, we should move these in a base class.
        public override bool Equals(object? obj)
        {
            var other = obj as LastName;
            if (other == null) return false;
            return Value == other.Value;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
