using SentIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Interfaces
{
    public interface INavigator
    {
        public event Action CurrentViewModelChanged;
        public event Action PreviousViewModelChanged;
        public ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase PreviousViewModel { get; set; }
    }
}
