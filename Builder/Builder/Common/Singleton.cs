using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        private Singleton() { }

        public static T Instance
        {
            get
            {
                if (_instance == null) _instance = new T();
                return _instance;
            }
        }
    }
}
