using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common
{
    class HTMLBuilder : Builder
    {
        private string res = "";
        public override void MakeTitle(string title)
        {
            res += "<html>\n<head>\n";
            res += "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";//文字コードを指定
            res += "</head>\n<body>\n";
            res += $"<h1>{title}</h1>\n";
        }
        public override void MakeString(string str)
        {
            res += $"<p>{str}</p>\n";
        }
        public override void MakeItems(string[] items)
        {
            res += "<ul>\n";
            foreach (var item in items)
            {
                res += $"<li>{item}</li>\n";
            }
            res += "</ul>\n";
        }
        public override void Close()
        {
            res += "</body>\n</html>\n";
        }
        public string GetResult() => res;
    }
}
