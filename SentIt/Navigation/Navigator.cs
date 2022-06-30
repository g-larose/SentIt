using SentIt.Interfaces;
using SentIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Navigation
{
    public class Navigator : INavigator
    {
        public ViewModelBase? CurrentViewModel { get; set; }

        public event Action? CurrentViewModelChanged;
    }
}
