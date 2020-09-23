using FirebaseAuthApp.ViewModels;
using System;
using Xamarin.Forms;

namespace FirebaseAuthApp
{
	public partial class MainPage : ContentPage
	{
		private MainViewModel _viewModel;
		public MainPage()
		{
			InitializeComponent();
			_viewModel = new MainViewModel(Navigation);
		}

		private void Login_Button_Clicked(object sender, EventArgs e) => _viewModel.OnLogin();

		private void Register_Button_Clicked(object sender, EventArgs e) => _viewModel.OnRegister();
	}
}
