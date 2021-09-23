using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse() // IsIsbn  ����������� � null, �� ��� ������ ������� false
        {
            bool actual = Book.IsIsbn(null); // ��������� ���������� � actual

            Assert.False(actual); // ���������, ���� ��������� � actual, �� ���� �������
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse() // IsIsbn  ����������� � ���������, �� ��� ������ ������� false
        {
            bool actual = Book.IsIsbn("  ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse() // IsIsbn  ����������� � ������������ �������, �� ��� ������ ������� false
        {
            bool actual = Book.IsIsbn("ISBN 123");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_With10_ReturnTrue() // IsIsbn  ����������� � 10 �������, �� ��� ������ ������� true
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_With13_ReturnTrue() //  IsIsbn  ����������� � 13 �������, �� ��� ������ ������� true
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse() // IsIsbn  ����������� � ������������ ������� � ������, �� ��� ������ ������� false
        {
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 0 yyy");

            Assert.False(actual);
        }
    }
}
