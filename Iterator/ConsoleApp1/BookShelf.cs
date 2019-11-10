using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BookShelf : IAggregate
    {
        private Book[] books;
        private int last = 0;
        public BookShelf(int maxsize)
        {
            this.books = new Book[maxsize];
        }
        public Book GetBookAt(int index)
        {
            return books[index];
        }
        public void AppendBook(Book book)
        {
            this.books[last] = book;
            last++;
        }
        public int GetLength()
        {
            return last;
        }
        public IIterator iterator()
        {
            return new BookShelfIterator(this);
        }
    }
}
