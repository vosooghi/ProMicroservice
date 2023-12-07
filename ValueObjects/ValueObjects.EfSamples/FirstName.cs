namespace ValueObjects.EfSamples
{
    public class FirstName
    {
        public string Value { get;private set; }
        private FirstName()
        {
            
        }
        public FirstName(string value)
        {
            //checking
            Value = value;
        }
    }
}
