namespace ValueObjects.EfSamples
{
    public class LastName
    {
        public string Value { get; private set; }
        public LastName(string value)
        {
            Value = value;
        }
    }
}
