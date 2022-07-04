namespace SentIt.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private AppViewModel _appViewModel;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public CommandBase? NavigateHomeCommand { get; }
        public CommandBase? NavigateFileShareCommand { get; }
        public CommandBase? NavigateChatCommand { get; }
        public CommandBase? NavigateSettingsCommand { get; }
        public RelayCommand PowerOffCommand { get; }

        private Singleton Instance { get; } = Singleton.Instance;

        private bool _isReady;
        public bool IsReady
        {
            get => _isReady;
            set => OnPropertyChanged(ref _isReady, value);
        }

        private string _tag;
        public string Tag
        {
            get => _tag;
            set => OnPropertyChanged(ref _tag, value);
        }

        private string _currentDate;
        public string CurrentDate
        {
            get => _currentDate;
            set => OnPropertyChanged(ref _currentDate, value);
        }
        public AppViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _appViewModel = this;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;

            Tag = "Main Window";
            CurrentDate = DateTime.Now.ToShortDateString();

            NavigateFileShareCommand = new NavigateCommand<FileTransferViewModel>(_navigator, () => new FileTransferViewModel(_navigator, _appViewModel));
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(_navigator, () => new ChatViewModel(_navigator, _appViewModel));
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigator, () => new HomeViewModel(_navigator, _appViewModel));
            PowerOffCommand = new RelayCommand(PowerOff);
        }

        private void PowerOff()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
