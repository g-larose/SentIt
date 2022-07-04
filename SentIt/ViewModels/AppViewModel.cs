using SentIt.Commands;
using SentIt.Globals;
using SentIt.Interfaces;
using SentIt.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SentIt.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private AppViewModel _appViewModel;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public ViewModelBase PreviousViewModel => _navigator.PreviousViewModel;
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


        public AppViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _appViewModel = this;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigator.PreviousViewModelChanged += _navigator_PreviousViewModelChanged;
            
            NavigateFileShareCommand = new NavigateCommand<FileTransferViewModel>(_navigator, () => new FileTransferViewModel(_navigator, _appViewModel));
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(_navigator, () => new ChatViewModel());
            PowerOffCommand = new RelayCommand(PowerOff);
        }

        private void _navigator_PreviousViewModelChanged()
        {
            OnPropertyChanged(nameof(PreviousViewModel));
        }

        private void PowerOff()
        {
            Application.Current.Shutdown();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
