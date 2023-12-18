using AggregateSamples.Framework;

namespace Introduction.AddressBooks
{
    public class AddressLine:Entity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsDefault { get; set; }

    }
}
