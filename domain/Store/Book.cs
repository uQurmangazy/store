using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public Book(int id, string isbn, string author, string title)
        {
            Id = id;
            Isbn = isbn;
            Author = author;
            Title = title;
        }
        public int Id { get; }
        public string Isbn { get; }
        public string Author { get; }    // в реальном проекте будет не Author, а id авторов
        public string Title { get; }

        internal static bool IsIsbn(string s) // интернал для того, чтобы был невиден для других проектов (виден внутри своего проекта)
        {
            if (s == null)
                return false;
            s = s.Replace("-", "") // поменяли все дефисы на ""
                 .Replace(" ", "") // поменяли все пробелы на ""
                 .ToUpper();       // сделали все буквы прописными

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$"); // возвращает true, если строка будет совпадать с переданным шаблоном ("ISBN\\d{10}") или @"ISBN\d{10}" 10 digit, тоесть цифров (@ - выключает экранирование)
                                                              // @"ISBN\d{10}" - означает должно совпадать слово ISBN и 10 цифр после него без дефисов и пробелов
                                                              // @"^ISBN\d{10}" - " ^ " - означает всегда совпадает с началом строки (ISBN быть должен точно в начале)
                                                              // @"^ISBN\d{10}(\d{3})?" - означает что 10 или еще возможно 3 цифра дополнительных (тоесть 10 + 3) ---- (\d{3})? -----
                                                              // @"^ISBN\d{10}(\d{3})?$" - " $ " - означает всегда совпадает с началом строки (после последней цифры должен быть конец строки) или после 10й цифры, или после 13й цифры
        }
    }
}
