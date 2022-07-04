namespace SentIt.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly AppViewModel _appViewModel;

        private bool _isReady;
        public bool IsReady
        {
            get => _isReady;
            set => OnPropertyChanged(ref _isReady, value);
        }

        private ObservableCollection<ChatMessage> _messages;
        public  ObservableCollection<ChatMessage> Messages
        {
            get => _messages;
            set => OnPropertyChanged(ref _messages, value);
        }
        public ChatViewModel(INavigator navigator, AppViewModel appViewModel)
        {
            _navigator = navigator;
            _appViewModel = appViewModel;
            IsReady = _appViewModel.IsReady;
            _appViewModel.Tag = "Chat View";
            Messages = new ObservableCollection<ChatMessage>();
            Messages.Add(new ChatMessage { Author = "127.0.0.1", Id = new Guid(), Message = "Hello From The TCP Connection" });
            Messages.Add(new ChatMessage { Author = "192.168.254.12", Id = new Guid(), Message = "Hello From The TCP Connection" });
        }
    }
}
