using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepository bookRepository; // создается readonly переменная с типом IBookRepository
        public BookService(IBookRepository bookRepository) // принимает объект класса, который реализует интерфейс IBookRepository
        {
            this.bookRepository = bookRepository; // constructor injection
        }
        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return bookRepository.GetAllByIsbn(query);

            return bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}
