using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Core.Domain.Exceptions;
using Ground.Core.Domain.ValueObjects;

namespace BasicInfo.Core.Domain.Categoris.ValueObjects
{
    public class CategoryName : TinyString//BaseValueObject<CategoryName>
    {
        public CategoryName(string value):base(value)
        {
            
        }
        /* //Refactored with Tiny String ValueObject
        #region Properties
        public string Value { get; private set; }
        #endregion
        #region Equality Check
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Constructors and Factories
        public static CategoryName FromString(string value) => new CategoryName(value);
        public CategoryName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(CategoryName));
            }
            if (value.Length < 2 || value.Length > 50)
            {
                throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(CategoryName), "2", "50");
            }
            Value = value;
        }
        private CategoryName()
        {

        }
        #endregion

        #region Operator Overloading
        public static explicit operator string(CategoryName title) => title.Value;
        public static implicit operator CategoryName(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;
        #endregion

        */
    }
}
