using SentIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Globals
{
    public class Singleton : ViewModelBase
    {
        public static Singleton Instance { get; } = new Singleton();

        private bool _isReady = true;
        public bool IsReady
        {
            get => _isReady;
            set => OnPropertyChanged(ref _isReady, value);
        }
    }
}
