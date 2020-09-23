using FirebaseAuthApp.ViewModels;
using Xamarin.Forms;

namespace FirebaseAuthApp
{
	public partial class LoginPage : ContentPage
	{
		private LoginViewModel _viewModel;

		public LoginPage()
		{
			InitializeComponent();
			_viewModel = new LoginViewModel();
			BindingContext = _viewModel;
		}

		private void Login_Button_Clicked(object sender, System.EventArgs e) => _viewModel.OnLogin();
	}
}
