using Firebase.Auth;
using FirebaseAuthApp.iOS;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace FirebaseAuthApp.iOS
{
	public class FirebaseAuthentication : IFirebaseAuthentication
	{
		public async Task<string> LoginWithEmailPassword(string email, string password)
		{
			var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
			return await user.User.GetIdTokenAsync();
		}

		public async Task<string> RegisterWithEmailPassword(string email, string password)
		{
			var user = await Auth.DefaultInstance.CreateUserAsync(email, password);
			return await user.User.GetIdTokenAsync();
		}
	}
}