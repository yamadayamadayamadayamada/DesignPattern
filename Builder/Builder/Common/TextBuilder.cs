using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common
{
    /// <summary>
    /// Builderクラスのサブクラス
    /// GetResultで構築された文書を取得する
    /// </summary>
    public class TextBuilder : Builder
    {
        /// <summary>
        /// 本ではStringBuilderを使っているが、Appendしかしないので分かりやすく単にStringで
        /// （Builderの例題の中でBuilderを使うのはどうかと思います...）
        /// </summary>
        private string res = "";
        /// <summary>
        /// プレーンテキストでのタイトル
        /// </summary>
        public override void MakeTitle(string title)
        {
            res += "==========\n";
            res += $"「{title}」\n";
            res += "\n";
        }
        public override void MakeString(string str)
        {
            res += $"■{str}\n";
        }
        public override void MakeItems(string[] items)
        {
            foreach (var item in items)
            {
                res += $"・{item}\n";
            }
            res += "\n";
        }
        public override void Close()
        {
            res += "==========\n";
        }
        /// <summary>
        /// 完成した文書を取得する
        /// </summary>
        /// <returns>(string)完成した文書</returns>
        public string GetResult() => res;
    }
}
