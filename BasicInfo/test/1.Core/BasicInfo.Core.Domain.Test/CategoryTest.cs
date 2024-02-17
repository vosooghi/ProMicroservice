using BasicInfo.Core.Domain.Categoris.Entities;
using BasicInfo.Core.Domain.Categoris.Events;
using Ground.Core.Domain.Exceptions;

namespace BasicInfo.Core.Domain.Test
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategoryWhenAllDataIsValid()
        {
            //Arrange
            string name = "Sport";
            string title = "Ê—“‘";

            //Act
            Category category = new Category(name, title);
            var categoryCreatedEvent = category.GetEvents().Where(w => w.GetType() == typeof(CategoryCreated)).FirstOrDefault() as CategoryCreated;

            //Assert
            Assert.NotNull(category);

            Assert.NotNull(categoryCreatedEvent);
            Assert.Equal(title,category.Title);
            Assert.Equal(name,category.Name);
            Assert.Equal(title,categoryCreatedEvent.Title);
            Assert.Equal(name, categoryCreatedEvent.Name);
        }

        /* refactored with TinyString ValueObject
        [Fact]
        public void PreventFromCreatingCategoryWhenTitleIsNull()
        {
            //Arrange
            string name = "Sport";
            string title = "";
            //Act
            //Category category = new Category(name, title);

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }
        [Fact]
        public void PreventFromCreatingCategoryWhenNameIsNull()
        {
            //Arrange
            string name = "";
            string title = "Ê—“‘";
            //Act
            //Category category = new Category(name, title);

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }

        [Fact]
        public void PreventFromCreatingCategoryWhenTitleLengthIsLessThanTwo()
        {
            //Arrange
            string name = "Sport";
            string title = "Ê";
            //Act
            //Category category = new Category(name, title);
            
            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }

        [Fact]
        public void PreventFromCreatingCategoryWhenNameLengthIsLessThanTwo()
        {
            //Arrange
            string name = "S";
            string title = "Ê—“‘";
            //Act
            //Category category = new Category(name, title);

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }

        [Fact]
        public void PreventFromCreatingCategoryWhenTitleLengthIsMoreThan50()
        {
            //Arrange
            string name = "Sport";
            string title = "Ê—“‘".PadLeft(51,'_');
            //Act
            //Category category = new Category(name, title);

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }
        [Fact]
        public void PreventFromCreatingCategoryWhenNameLengthIsMoreThan50()
        {
            //Arrange
            string name = "Sport".PadLeft(51, '_');
            string title = "Ê—“‘";
            //Act
            //Category category = new Category(name, title);

            //Assert

            Assert.Throws<InvalidValueObjectStateException>(() => new Category(name, title));
        }
        */
    }
}