using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BookShelfIterator : IIterator
    {
        private BookShelf bookShelf;
        private int index;
        public BookShelfIterator(BookShelf bookShelf)
        {
            this.bookShelf = bookShelf;
            this.index = 0;
        }
        public bool HasNext()
        {
            return index < bookShelf.GetLength();
        }
        public object Next()
        {
            Book book = bookShelf.GetBookAt(index);
            index++;
            return book;
        }
    }
}
