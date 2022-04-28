using System.Collections.Generic;
using Context;
using Models;
using Moq;
using Services;
using Xunit;

namespace UnitTests
{
    public class BookServiceUnitTests
    {
        [Fact]
        public void DbBookService_GetBooks_ReturnsFullBooksList()
        {
            var command = "SELECT books.id, books.name, books.price, authors.name" +
                          " FROM books LEFT JOIN authors ON books.authors_id = authors.id";

            var fakeBooksAsListOfStringsArray = new List<string[]>
            {
                new[] {"0", "Name", "0", "Author name"},
                new[] {"0", "Name", "0", "Author name"},
                new[] {"0", "Name", "0", "Author name"},
            };

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command))
                .Returns(fakeBooksAsListOfStringsArray);

            var service = new DbBookService(mockRepository.Object);
            var books = service.GetBooks();

            Assert.Equal(3, books.Count);
            Assert.All(books, book => Assert.IsType<Book>(book));
        }

        [Fact]
        public void DbBookService_GetBooks_ReturnsEmptyList_ForEmptyDb()
        {
            var command = "SELECT books.id, books.name, books.price, authors.name" +
                          " FROM books LEFT JOIN authors ON books.authors_id = authors.id";

            var fakeBooksAsListOfStringsArray = new List<string[]>();

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command))
                .Returns(fakeBooksAsListOfStringsArray);

            var service = new DbBookService(mockRepository.Object);
            var books = service.GetBooks();

            Assert.IsType<List<Book>>(books);
            Assert.NotNull(books);
            Assert.Empty(books);
        }

        [Fact]
        public void DbBookService_GetBookByName_ReturnsBook()
        {
            var command = "SELECT books.id, books.name, books.price, authors.name" +
                          $" FROM books LEFT JOIN authors ON books.authors_id = authors.id";

            var fakeBookAsListOfStringsArray = new List<string[]>
            {
                new[] {"0", "Name", "0", "Author name"},
            };

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command))
                .Returns(fakeBookAsListOfStringsArray);

            var service = new DbBookService(mockRepository.Object);
            var book = service.GetBookByName("Name");

            Assert.NotNull(book);
            Assert.IsType<Book>(book);
        }

        [Fact]
        public void DbBookService_GetBookByName_ReturnsNull_ForNotExistingBook()
        {
            var command = "SELECT books.id, books.name, books.price, authors.name" +
                          $" FROM books LEFT JOIN authors ON books.authors_id = authors.id";

            var fakeBookAsListOfStringsArray = new List<string[]>();

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command))
                .Returns(fakeBookAsListOfStringsArray);

            var service = new DbBookService(mockRepository.Object);
            var book = service.GetBookByName("NotBookName");

            Assert.Null(book);
        }

        [Fact]
        public void DbBookService_CreateBook_ReturnsTrue_ForValidInput()
        {
            var testBook = new Book
            {
                Author = "Author",
                Id = 1,
                Name = "Name",
                Price = 1,
            };

            var fakeAuthorData = new List<string[]> {new[] {"1"}};

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                           $"VALUES ('{testBook.Name}', '{testBook.Price}', '{fakeAuthorData[0][0]}')";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(1);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.CreateBook(testBook);

            Assert.True(creationResult);
        }

        [Fact]
        public void DbBookService_CreateBook_ReturnsFalse_ForInvalidAuthor()
        {
            var testBook = new Book
            {
                Author = "Author",
                Id = 1,
                Name = "Name",
                Price = 1,
            };

            var fakeAuthorData = new List<string[]>();

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                           $"VALUES ('{testBook.Name}', '{testBook.Price}', '{fakeAuthorData[0][0]}')";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(1);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.CreateBook(testBook);

            Assert.True(creationResult);
        }

        [Fact]
        public void DbBookService_CreateBook_ReturnsFalse_ForBookEqualsNull()
        {
            var testBook = null as Book;

            var fakeAuthorData = new List<string[]> {new[] {"1"}};

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                           $"VALUES ('{testBook.Name}', '{testBook.Price}', '{fakeAuthorData[0][0]}')";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(0);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.CreateBook(testBook);

            Assert.False(creationResult);
        }

        [Fact]
        public void DbBookService_DeleteBookById_ReturnsTrue_ForValidInput()
        {
            uint fakeId = 1;
            var command = $"DELETE FROM books WHERE books.id = {fakeId}";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.Execute(command))
                .Returns(1);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.DeleteBookById(fakeId);

            Assert.True(creationResult);
        }

        [Fact]
        public void DbBookService_DeleteBookById_ReturnsTrue_ForNotExistingId()
        {
            uint fakeId = 1;
            var command = $"DELETE FROM books WHERE books.id = {fakeId}";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.Execute(command))
                .Returns(0);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.DeleteBookById(fakeId);

            Assert.False(creationResult);
        }

        [Fact]
        public void DbBookService_EditBook_ReturnsTrue_ForValidInput()
        {
            var testBook = new Book
            {
                Author = "Author",
                Id = 1,
                Name = "Name",
                Price = 1,
            };

            var fakeAuthorData = new List<string[]> {new[] {"1"}};

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"UPDATE books SET books.name = '{testBook.Name}', books.price = {testBook.Price}, "
                           + $"books.authors_id = {fakeAuthorData[0][0]} WHERE books.id = {testBook.Id}";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(1);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.EditBook(testBook);

            Assert.True(creationResult);
        }

        [Fact]
        public void DbBookService_EditBook_ReturnsFalse_ForInvalidAuthor()
        {
            var testBook = new Book
            {
                Author = "Author",
                Id = 1,
                Name = "Name",
                Price = 1,
            };

            var fakeAuthorData = new List<string[]>();

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"UPDATE books SET books.name = '{testBook.Name}', books.price = {testBook.Price}, "
                           + $"books.authors_id = {fakeAuthorData[0][0]} WHERE books.id = {testBook.Id}";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(1);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.EditBook(testBook);

            Assert.True(creationResult);
        }

        [Fact]
        public void DbBookService_EditBook_ReturnsFalse_ForBookEqualsNull()
        {
            var testBook = null as Book;

            var fakeAuthorData = new List<string[]> {new[] {"1"}};

            var command1 = $"SELECT authors.id FROM authors WHERE authors.name = '{testBook.Author}'";
            var command2 = $"UPDATE books SET books.name = '{testBook.Name}', books.price = {testBook.Price}, "
                           + $"books.authors_id = {fakeAuthorData[0][0]} WHERE books.id = {testBook.Id}";

            var mockRepository = new Mock<IApplicationContext>();
            mockRepository
                .Setup(repo => repo.ToList(command1))
                .Returns(fakeAuthorData);
            mockRepository
                .Setup(repo => repo.Execute(command2))
                .Returns(0);

            var service = new DbBookService(mockRepository.Object);
            var creationResult = service.EditBook(testBook);

            Assert.False(creationResult);
        }
    }
}