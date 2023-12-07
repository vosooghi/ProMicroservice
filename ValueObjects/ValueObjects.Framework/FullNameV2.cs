namespace ValueObjects.Framework
{
    public class FullNameV2 : BaseValueObjectV2<FullNameV2>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FullNameV2(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override IEnumerable<object> GetEqaulityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
