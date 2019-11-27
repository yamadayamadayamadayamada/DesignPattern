using Builder.Common;
using Builder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Builder.ViewModel
{
    class Page2ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region インターフェイスの実装
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string this[string columnName] => throw new NotImplementedException();
        public string Error => throw new NotImplementedException();
        #endregion

        #region 状態
        private bool _button1IsEnabled;
        private bool _button2IsEnabled;
        private string _text;
        #endregion

        #region ViewModel -> View
        public EventHandler changeWebBrowserHandler;
        internal static void Initialize()
        {

            //特になし
        }
        public bool Button1IsEnabled
        {
            get { return _button1IsEnabled; }
            set
            {
                _button1IsEnabled = value;
                OnPropertyChanged("Button1IsEnabled");
            }
        }
        public bool Button2IsEnabled
        {
            get { return _button2IsEnabled; }
            set
            {
                _button2IsEnabled = value;
                OnPropertyChanged("Button2IsEnabled");
            }
        }
        public string TextSource
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("TextSource");
            }
        }
        #endregion


        #region View->ViewModel
        public ICommand LoadedCommand => new LoadCommand();
        public ICommand Button1ClickedCommand => new Button1Command();
        public ICommand Button2ClickedCommand => new Button2Command();


        internal class LoadCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Initialize();
            }
        }
        internal class Button1Command : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                //Modelの関数を実行
                var html = Singleton<MainModel>.Instance.HTMLScenario();

                var viewModel = GetViewModel();
                //Viewに反映
                viewModel.TextSource = html;
                viewModel.changeWebBrowserHandler(new object(), new WebArgs(html));
            }
        }
        internal class Button2Command : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                var navigationWindow = (NavigationWindow)Application.Current.MainWindow;
                navigationWindow.GoBack();
            }
        }

        #endregion
        public class WebArgs : EventArgs
        {
            public string str;
            public WebArgs(string str)
            {
                this.str = str;
            }
        }

        private static Page2ViewModel GetViewModel()
        {
            var model = Singleton<MainModel>.Instance;
            if (model.ViewModel == null) throw new ArgumentNullException("ModelのViewModelがnullです");
            if (model.ViewModel as Page2ViewModel == null) throw new InvalidCastException("ModelのViewModelの型が間違っています");
            return (Page2ViewModel)model.ViewModel;
        }
    }
}
