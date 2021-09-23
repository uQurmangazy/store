using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse() // IsIsbn  запускается с null, то она должна вернуть false
        {
            bool actual = Book.IsIsbn(null); // результат передается в actual

            Assert.False(actual); // проверяет, если совпадает с actual, то тест пройдет
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse() // IsIsbn  запускается с пробелами, то она должна вернуть false
        {
            bool actual = Book.IsIsbn("  ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse() // IsIsbn  запускается с неправильным номером, то она должна вернуть false
        {
            bool actual = Book.IsIsbn("ISBN 123");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_With10_ReturnTrue() // IsIsbn  запускается с 10 цифрами, то она должна вернуть true
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_With13_ReturnTrue() //  IsIsbn  запускается с 13 цифрами, то она должна вернуть true
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse() // IsIsbn  запускается с неправильным началом и концом, то она должна вернуть false
        {
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 0 yyy");

            Assert.False(actual);
        }
    }
}
