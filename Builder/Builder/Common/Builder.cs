using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common
{
    /// <summary>
    /// 「文書」を作るメソッドを宣言する抽象クラス
    /// それぞれのメソッドが決まった構造を文書に構築する
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// タイトルを構築する
        /// </summary>
        /// <param name="title"></param>
        public abstract void MakeTitle(string title);
        /// <summary>
        /// 文字列を構築する
        /// </summary>
        /// <param name="str"></param>
        public abstract void MakeString(string str);
        /// <summary>
        /// 箇条書きを構築する
        /// </summary>
        /// <param name="items"></param>
        public abstract void MakeItems(string[] items);
        /// <summary>
        /// 文書を完成させる
        /// </summary>
        public abstract void Close();
    }
}
