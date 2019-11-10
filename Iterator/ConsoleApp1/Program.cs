using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //４冊入る本棚を作る
            BookShelf bookShelf = new BookShelf(4);
            //本を入れる
            bookShelf.AppendBook(new Book("はじぱた"));
            bookShelf.AppendBook(new Book("PRML"));
            bookShelf.AppendBook(new Book("Information Theory"));
            bookShelf.AppendBook(new Book("デザインパターン入門"));
            //本棚のIteratorを取り出す
            IIterator it = bookShelf.iterator();
            //Iteratorから次の本にアクセスする
            while (it.HasNext())
            {
                Book book = (Book)it.Next();
                Console.WriteLine(book.GetName());
            }

            Console.ReadLine();
        }
    }
}
