using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositotySub = new Mock<IBookRepository>();  // библиотека Moq позволяет делать заглушки для интерфейсов и абстрактных классов
            // Moq создает объект который наследует IBookRepository, у него естесно есть метод GetAllByIsbn
            bookRepositotySub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())) // когда будет вызываться этот метод, этого объекта с любым строковым параметром (It.IsAny<string>())
                             .Returns(new[] { new Book(1, "", "", "") });    // ты верни вот такой вот массив

            bookRepositotySub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                             .Returns(new[] { new Book(2, "", "", "") }); // по сути мы ловим вызовы методов

            var bookService = new BookService(bookRepositotySub.Object);

            var validIsbn = "ISBN 12345-67890";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositotySub = new Mock<IBookRepository>();  // библиотека Moq позволяет делать заглушки для интерфейсов и абстрактных классов
            // Moq создает объект который наследует IBookRepository, у него естесно есть метод GetAllByIsbn
            bookRepositotySub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())) // когда будет вызываться этот метод, этого объекта с любым строковым параметром (It.IsAny<string>())
                             .Returns(new[] { new Book(1, "", "", "") });    // ты верни вот такой вот массив

            bookRepositotySub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                             .Returns(new[] { new Book(2, "", "", "") }); // по сути мы ловим вызовы методов

            var bookService = new BookService(bookRepositotySub.Object);

            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
