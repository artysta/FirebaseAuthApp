using Xamarin.Forms;

namespace FirebaseAuthApp.ViewModels
{
	class MainViewModel : BaseViewModel
	{
		private INavigation _navigation;

		public MainViewModel(INavigation navigation) => _navigation = navigation;

		public async void OnLogin() => await _navigation.PushAsync(new LoginPage());

		public async void OnRegister() => await _navigation.PushAsync(new RegisterPage());
	}
}
