using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAample.Common;
using WpfAample.Model;
using static WpfAample.Model.MainModel;

namespace WpfAample.ViewModel
{
    class MainViewModel : INotifyPropertyChanged, IDataErrorInfo
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
        ObservableCollection<DataGridForm> _dataGridSource;
        #endregion




        #region ViewModel -> View
        internal static void Initialize()
        {
            var model = Singleton<MainModel>.Instance;
            if (model.ViewMode == null) throw new ArgumentNullException("ModelのViewModelがnullです");
            if (model.ViewMode as MainViewModel == null) throw new InvalidCastException("ModelのViewModelの型が間違っています");
            var viewModel = (MainViewModel)model.ViewMode;

            viewModel.Button1IsEnabled = true;
            viewModel.Button2IsEnabled = false;
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
        public ObservableCollection<DataGridForm> DataGridSource
        {
            get => _dataGridSource;
            set
            {
                _dataGridSource = value;
                OnPropertyChanged("DataGridSource");
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
                var model = Singleton<MainModel>.Instance;
                if (model.ViewMode == null) throw new ArgumentNullException("ModelのViewModelがnullです");
                if (model.ViewMode as MainViewModel == null) throw new InvalidCastException("ModelのViewModelの型が間違っています");
                var viewModel = (MainViewModel)model.ViewMode;

                //Modelの関数を実行
                Singleton<MainModel>.Instance.Scenario1();

                //Viewを更新
                viewModel.Button1IsEnabled = false;
                viewModel.Button2IsEnabled = true;

                var tmp = model.Comments.Select(p => new DataGridForm(p)).ToArray();
                viewModel.DataGridSource = new ObservableCollection<DataGridForm>(tmp);
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
                var model = Singleton<MainModel>.Instance;
                if (model.ViewMode == null) throw new ArgumentNullException("ModelのViewModelがnullです");
                if (model.ViewMode as MainViewModel == null) throw new InvalidCastException("ModelのViewModelの型が間違っています");
                var viewModel = (MainViewModel)model.ViewMode;

                Singleton<MainModel>.Instance.Scenario2();

                viewModel.Button1IsEnabled = true;
                viewModel.Button2IsEnabled = false;

                var tmp = model.Comments.Select(p => new DataGridForm(p)).ToArray();
                viewModel.DataGridSource = new ObservableCollection<DataGridForm>(tmp);
            }
        }

        #endregion

        public class DataGridForm
        {
            public string str { get; set; }
            public string time { get; set; }
            public DataGridForm(Comment comment)
            {
                str = comment.str.ToString();
                time = comment.time.ToString();
            }
        }
    }

}
