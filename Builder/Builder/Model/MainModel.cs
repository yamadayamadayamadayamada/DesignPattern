using Builder.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Model
{
    class MainModel
    {
        public object ViewModel { get; internal set; }

        internal void SetViewModel<T>(T viewModel) where T : INotifyPropertyChanged
        {
            ViewModel = viewModel;
        }
        public string TextScenario()
        {
            var builder = new TextBuilder();
            Director director = new Director(builder);
            //文書を作成
            director.Construct();
            //作成した文書
            return builder.GetResult();
        }
        public string HTMLScenario()
        {
            var builder = new HTMLBuilder();
            Director director = new Director(builder);
            //文書を作成
            director.Construct();
            //作成した文書
            return builder.GetResult();
        }
    }
}
