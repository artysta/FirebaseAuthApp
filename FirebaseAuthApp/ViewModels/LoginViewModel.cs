using System;
using Xamarin.Forms;

namespace FirebaseAuthApp.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		private string _email = "";
		public string Email
		{
			set => SetProperty(ref _email, value);
			get => _email;
		}

		private string _password = "";
		public string Password
		{
			set => SetProperty(ref _password, value);
			get => _password;
		}

		private bool _isBusy;
		public bool IsBusy
		{
			set => SetProperty(ref _isBusy, value);
			get => _isBusy;
		}

		public async void OnLogin()
		{
			IsBusy = true;

			try
			{
				IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
				string token = await auth.LoginWithEmailPassword(Email, Password);
				await Application.Current.MainPage.DisplayAlert("Success!", $"Auth token: { token }.", "Ok");
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", $"Something went wrong: { e.Message }", "Ok");
			}

			IsBusy = false;
		}
	}
}
