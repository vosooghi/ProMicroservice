using BasicInfo.Core.Domain.Categoris.Entities;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo.Core.Domain.Test.Common.ValueObjects
{
    public class TinyStringTest
    {
        [Fact]
        public void CreateTinyStringWhenAllDataAreValid()
        {
            //Arrange
            string value = "ورزش";

            //Act
            TinyString tinyString = new TinyString(value);

            //Assert
            Assert.NotNull(tinyString);
            Assert.Equal(value, tinyString.Value);
        }
        [Theory]
        [InlineData("")]
        [InlineData("و")]
        [InlineData("012345678901234567890123456789012345678901234567890")]//51
        public void PreventFromCreatingTinyStringWhenValueIsInvalid(string inputValue)
        {
            //Arrange
            string value = "";

            //Act            

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new TinyString(value));
        }

       /* [Fact]
        public void PreventFromCreatingTinyStringWhenTitleLengthIsLessThanTwo()
        {
            //Arrange
            string value = "و";
            //Act


            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new TinyString(value));
        }
        [Fact]
        public void PreventFromCreatingTinyStringWhenTitleLengthIsMoreThan50()
        {
            //Arrange
            string value = "ورزش".PadLeft(51, '_');
            //Act

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new TinyString(value));
        }*/
    }
}
