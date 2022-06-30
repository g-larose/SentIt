using SentIt.Commands;
using SentIt.Interfaces;
using SentIt.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;

        public CommandBase? NavigateHomeCommand { get; }
        public CommandBase? NavigateFileShareCommand { get; }
        public CommandBase? NavigateChatCommand { get; }
        public CommandBase? NavigateSettingsCommand { get; }

        public AppViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateFileShareCommand = new NavigateCommand<FileTransferViewModel>(_navigator, () => new FileTransferViewModel(_navigator));
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(_navigator, () => new ChatViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
