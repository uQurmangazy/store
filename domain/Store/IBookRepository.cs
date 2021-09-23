using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    // Service Layer Логика
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);//метод возвращает массив (несколько) книг (можно узнать по типу метода Book[])
        // метод получает на вход часть названия книги
        // Если массив возвращает несколько значений то добавлять All в название метода (GetAllByTitle)
    }
}
