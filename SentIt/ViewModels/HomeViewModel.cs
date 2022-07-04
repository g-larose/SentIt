namespace SentIt.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigator _navigator;
        private AppViewModel _appViewModel;

        public HomeViewModel(INavigator navigator, AppViewModel appViewModel)
        {
            _navigator = navigator;
            _appViewModel = appViewModel;
            _appViewModel.Tag = "Home View";
        }
    }
}
