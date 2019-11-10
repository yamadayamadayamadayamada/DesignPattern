using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_継承_
{
    public class Banner
    {
        private string str;
        public Banner(string str)
        {
            this.str = str;
        }
        //文字をかっこでくくって表示する
        public void ShowWithParen()
        {
            Console.WriteLine("({0})", str);
        }
        //文字をアスタリスクでくくって表示する
        public void ShowWithAster()
        {
            Console.WriteLine("*{0}*", str);
        }
    }
}
