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
            new Book(1, "Art of programming"),
            new Book(2,"Refactoring"),
            new Book(3, "C Programming Language")
        };
        public Book[] GetAllByTitle(string titlePart)// метод возвращает список, а точнее массив книг
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();//фильтрация массива по критерию
            // критерий: возвращать массив книг, содержащих titlePart в названии
            // для этого: берем массив books и выполняем команду Where, который позволяет отобрать по лямбде-выражения предикат
            // Это функция с одним параметром book, который возвращает true когда у book есть Title, который содержит titlePart
            //  titlePart ToArray
        }
    }
}
