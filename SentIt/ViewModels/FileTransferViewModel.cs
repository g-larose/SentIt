using SentIt.Commands;
using SentIt.Globals;
using SentIt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SentIt.ViewModels
{
    public class FileTransferViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private AppViewModel _appViewModel;
        public ICommand SelectFileCommand { get; } 

        private bool isReady;
        public bool IsReady
        {
            get => isReady;
            set => OnPropertyChanged(ref isReady, value);
        }

        private string _selectedFile;
        public string SelectedFile
        {
            get => _selectedFile;
            set => OnPropertyChanged(ref _selectedFile, value);
        }

        public FileTransferViewModel(INavigator navigator, AppViewModel appViewModel)
        {
            _navigator = navigator;
            _appViewModel = appViewModel;
            SelectFileCommand = new RelayCommand(SelectFile);
        } 

        private void SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (ofd.FileName != null || ofd.FileName != "")
            {
                int index = ofd.FileName!.LastIndexOf("\\");
                SelectedFile = ofd.FileName.Substring(index + 1);
                IsReady = true;
                _appViewModel.IsReady = true;
            }
                

          


        }
    }
}
