using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);//метод возвращает массив (несколько) книг (можно узнать по типу метода Book[])
        // метод получает на вход часть названия книги
        // Если массив возвращает несколько значений то добавлять All в название метода (GetAllByTitle)
    }
}
