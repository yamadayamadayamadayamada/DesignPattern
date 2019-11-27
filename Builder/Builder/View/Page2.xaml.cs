using Builder.Common;
using Builder.Model;
using Builder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Builder.ViewModel.Page2ViewModel;

namespace Builder.View
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            var model = Singleton<MainModel>.Instance;
            model.SetViewModel(new Page2ViewModel());
            this.DataContext = model.ViewModel;

            //受信ハンドラ(webbrowserをViewModelから帰る方法がわからなかったのでイベントハンドラで無理やり・・・)
            ((Page2ViewModel)model.ViewModel).changeWebBrowserHandler +=
                (object o, EventArgs e) => browser.NavigateToString(((WebArgs)e).str);
        }
    }
}
