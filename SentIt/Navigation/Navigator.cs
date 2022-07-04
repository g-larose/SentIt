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
        public event Action? CurrentViewModelChanged;
        public event Action? PreviousViewModelChanged;

        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private ViewModelBase? _previousViewModel;
        public ViewModelBase? PreviousViewModel
        {
            get => _previousViewModel;
            set
            {
                _previousViewModel = value;
                OnPreviousViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private void OnPreviousViewModelChanged()
        {
            PreviousViewModelChanged?.Invoke();
        }
    }
}
