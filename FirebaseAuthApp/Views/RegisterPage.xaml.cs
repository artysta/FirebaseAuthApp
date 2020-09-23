using FirebaseAuthApp.ViewModels;
using Xamarin.Forms;

namespace FirebaseAuthApp
{
	public partial class RegisterPage : ContentPage
	{
		private RegisterViewModel _viewModel;

		public RegisterPage()
		{
			InitializeComponent();
			_viewModel = new RegisterViewModel();
			BindingContext = _viewModel;
		}

		private void Register_Button_Clicked(object sender, System.EventArgs e) => _viewModel.OnRegister();
	}
}
