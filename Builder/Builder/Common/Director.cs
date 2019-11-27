using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common
{
    /// <summary>
    /// Builderクラスで宣言されているメソッドを使って文書を作るクラス
    /// </summary>
    class Director
    {
        private Builder builder;
        /// <summary>
        /// Directorのコンストラクタ
        /// </summary>
        /// <param name="builder">Builderクラスのサブクラス（Builderクラスは抽象クラスであるため、引数にとれない）</param>
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        /// <summary>
        /// Builderに文字を渡して文書を作成する
        /// </summary>
        public void Construct()
        {
            builder.MakeTitle("Greeting");
            builder.MakeString("朝から夜にかけて");
            builder.MakeItems(new string[]
            {
                "おはよう",
                "こんにちは"
            });
            builder.MakeString("夜に");
            builder.MakeItems(new string[]
            {
                "こんばんは",
                "おやすみなさい",
                "さようなら"
            });
            builder.Close();
        }
    }
}
