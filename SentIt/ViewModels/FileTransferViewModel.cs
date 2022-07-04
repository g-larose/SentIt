namespace SentIt.ViewModels
{
    public class FileTransferViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private AppViewModel _appViewModel;

        public event TextChangedEventHandler TextChanged;
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
            TextChanged += FileTransferViewModel_TextChanged1;
            SelectFileCommand = new RelayCommand(SelectFile);
            _appViewModel.Tag = "File Transfer View";

           
        }

        private void FileTransferViewModel_TextChanged1(object sender, TextChangedEventArgs e)
        {
          
        }

        private void FileTransferViewModel_TextChanged(object? sender, EventArgs e)
        {
            //if (sender.GetType() == typeof(TextBox))
            //{
            //    var textBox = sender as TextBox;
            //    if (textBox?.Text.Length < 1)
            //        IsReady = false;
            //}
        
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
