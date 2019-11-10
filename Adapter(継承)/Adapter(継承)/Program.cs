using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_継承_
{
    class Program
    {
        static void Main(string[] args)
        {

            IPrint print = new PrintBanner("Hello");
            print.PrintWeek();
            print.PrintStrong();

            Console.ReadLine();
        }
    }
}
