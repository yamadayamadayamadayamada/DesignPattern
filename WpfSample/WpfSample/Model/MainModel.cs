using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAample.Model
{
    public class MainModel
    {
        public object ViewMode { get; private set; }
        public List<Comment> Comments { get; private set; }

        public void Inisialilze<T>(T viewModel) where T : INotifyPropertyChanged
        {
            ViewMode = viewModel;
            Comments = new List<Comment>();
        }

        public void Scenario1()
        {
            Comments.Add(new Comment("Button1が押されました",DateTime.Now));
        }
        public void Scenario2()
        {
            Comments.Add(new Comment("Button2が押されました", DateTime.Now));
        }

        public class Comment
        {
            public string str;
            public DateTime time;
            public Comment(string str,DateTime time)
            {
                this.str = str;
                this.time = time;
            }
        }
    }
}
