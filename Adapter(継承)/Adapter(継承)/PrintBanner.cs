using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_継承_
{
    /// <summary>
    /// BannerにIPrintを実装するアダプタクラスです
    /// 用意されているBannerを継承しつつ、要求されるIPrintを実装します
    /// </summary>
    public class PrintBanner : Banner, IPrint
    {
        public PrintBanner(string str) : base(str) { }
        void IPrint.PrintWeek()
        {
            ShowWithParen();
        }
        void IPrint.PrintStrong()
        {
            ShowWithAster();
        }
    }
}
