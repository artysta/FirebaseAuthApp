using Firebase.Auth;
using FirebaseAuthApp.Droid;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace FirebaseAuthApp.Droid
{
	public class FirebaseAuthentication : IFirebaseAuthentication
	{
		public async Task<string> LoginWithEmailPassword(string email, string password)
		{
			var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
			var token = await user.User.GetIdTokenAsync(false);
			return token.Token;
		}

		public async Task<string> RegisterWithEmailPassword(string email, string password)
		{
			var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
			var token = await user.User.GetIdTokenAsync(false);
			return token.Token;
		}
	}
}