using FluentAssertions;
using LibraryProject;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace TestLibraryProject
{
    public class BookTest
    {
        [Fact]
        public void TestBookDisplay_ValidInput()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            Book book = new Book("test", "test", 9999, "test", validationService);
            string expectedResult = "Title: test, Author: test, Publication Year: 9999, ISBN: test";

            // Act
            string actualResult = book.DisplayBookInfo();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DisplayBookInfo_SetBookTitle_ReturnsCorrectTitle()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565", validationService);
            string expected = "Title: The Great Gatsby, Author: F. Scott Fitzgerald, Publication Year: 1925, ISBN: 978-0743273565";

            // Act
            string actual = book.DisplayBookInfo();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookHasTitle_TitleIsCorrectAfterBookCreation()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var book = new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0061120084", validationService);

            // Act
            string title = book.Title;

            // Assert
            Assert.Equal("To Kill a Mockingbird", title);
        }


        [Fact]
        public void SortBooksByTitle_ReturnsBooksInAlphabeticalOrder()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var books = new List<Book>
            {
                new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0061120084", validationService),
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565", validationService),
                new Book("1984", "George Orwell", 1949, "978-0451524935", validationService)
            };
            var expectedOrder = new List<string> { "1984", "The Great Gatsby", "To Kill a Mockingbird" };

            // Act
            var orderedBooks = books.OrderBy(book => book.Title).ToList();
            var actualOrder = orderedBooks.Select(book => book.Title).ToList();

            // Assert
            Assert.Equal(expectedOrder, actualOrder);
        }

        [Fact]
        public void BookHasTitle_TitleIsCorrectAfterBookCreation2()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var book = new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0061120084", validationService);

            // Act
            var actual = book.Title;

            // Assert
            actual.Should().Be("To Kill a Mockingbird");

            // Assert.Equal("To Kill a Mockingbird", title);
        }

        [Fact]
        public void BookHasNegativePubYear_ThrowsArgumentException()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var book = new Book("To Kill a Mockingbird", "Harper Lee", -1960, "978-0061120084", validationService).Should().Throws<ArgumentException>();
        }

        [Fact]
        public void BookHasNegativePubYear_ThrowsArgumentException2()
        {
            var validationService = new ValidationService();
            Assert.Throws<ArgumentException>(() => new Book("To Kill a Mockingbird", "Harper Lee", -1960, "978-0061120084", validationService));
        }

        [Fact]
        public void BookHasValidPubYear_PubYearSetCorrectly()
        {
            // Arrange
            var validationService = new ValidationService();
            validationService
                .When(v => v.IsValidBookPubYear(-1))
                .Do(v => { throw new ArgumentException(); });
            var book = new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0061120084", validationService);

            // Act
            var actual = book.PublicationYear;

            // Assert
            actual.Should().Be(1960);

            // Assert.Equal("To Kill a Mockingbird", title);
        }







    }
}