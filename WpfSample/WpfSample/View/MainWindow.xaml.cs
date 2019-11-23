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
using WpfAample.Common;
using WpfAample.Model;
using WpfAample.ViewModel;

namespace WpfAample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Modelの初期化
            var model = Singleton<MainModel>.Instance;
            model.Inisialilze(new MainViewModel());

            this.DataContext = model.ViewMode;
        }
    }
}
