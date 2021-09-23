using System;
using System.Linq;

// Data Access Layer
// infrastucture потому что вместо sql там может быть что-то другое
namespace Store.Memory
{
    // Реализация IBookRepository без sql вместо него массив памяти
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art of Programming"),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring"),
            new Book(3, "ISBN 12312-31233", "B. Kernighan, D. Ritchie", "C Programming Language")
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(x => x.Isbn == isbn).ToArray(); // Linq запрос берет массив книг "books", прогоняет по нему предикат, тоесть сравнивает все книги по условию 
        }

        public Book[] GetAllByTitleOrAuthor(string query)// метод возвращает список, а точнее массив книг
        {
            return books.Where(book => book.Author.Contains(query) // фильтрация массива по критерию
                                    || book.Title.Contains(query))
                        .ToArray();
            // критерий: возвращать массив книг, содержащих titlePart в названии
            // для этого: берем массив books и выполняем команду Where, который позволяет отобрать по лямбде-выражению предикат
            // Это функция с одним параметром book, который возвращает true когда у book есть Title, который содержит titlePart
            //  titlePart ToArray
        }
    }
}
