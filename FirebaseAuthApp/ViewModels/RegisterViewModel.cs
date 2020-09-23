using System;
using Xamarin.Forms;

namespace FirebaseAuthApp.ViewModels
{
	class RegisterViewModel : BaseViewModel
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

		private string _passwordRepeat = "";
		public string PasswordRepeat
		{
			set => SetProperty(ref _passwordRepeat, value);
			get => _passwordRepeat;
		}

		private bool _isBusy;
		public bool IsBusy
		{
			set => SetProperty(ref _isBusy, value);
			get => _isBusy;
		}

		public async void OnRegister()
		{
			IsBusy = true;

			if (Password != PasswordRepeat)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", $"Passwords are not equal!", "Ok");
				IsBusy = false;
				return;
			}

			try
			{
				IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
				string token = await auth.RegisterWithEmailPassword(Email, Password);
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
