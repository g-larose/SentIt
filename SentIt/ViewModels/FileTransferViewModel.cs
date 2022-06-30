using SentIt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.ViewModels
{
    public class FileTransferViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        private bool isReady;
        public bool IsReady
        {
            get => isReady;
            set => OnPropertyChanged(ref isReady, value);
        }
        public FileTransferViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
