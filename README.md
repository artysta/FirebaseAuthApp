# FirebaseAuthApp

Simple Xamarin.Forms cross-platform (Android &amp; iOS) application presenting Firebase Authentication.

Remember to add Android & iOS applications to your Firebase project and download google services confing files. Put the files to the correct directories and change **Build Action** in the properties:

- FirebaseAuthApp\FirebaseAuthApp.Android\google-services.json (**Build Action -> GoogleServicesJson**),
- FirebaseAuthApp\FirebaseAuthApp.iOS\GoogleService-Info.plist (**Build Action -> BundleResource**).

---

### #0. Wanna cofigure your own cross-platform Fireabase Authentication project?

There are a few things you need to do in order to make Firebase Authentication working on both (Android & iOS) operating systems.

### #1. Start by creating new blank project for Android & iOS in the Visual Studio.

### #2. Configure shared project.
 - create **IFirebaseAuthentication** in shared project:

```c#
using System.Threading.Tasks;

namespace FirebaseAuthApp
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> RegisterWithEmailPassword(string email, string password);
    }
}
```

### #3. Configure Android project.
  - add [Xamarin.Firebase.Auth](https://www.nuget.org/packages/Xamarin.Firebase.Auth/) dependency using NuGet package manager,
  - create **FirebaseAuthentication** implementing **IFirebaseAuthentication** interface:
```c#
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
```
  - in **YourAppName**.Android.csproj (**FirebaseAuthApp**.Android.csproj in my case) file add:
```xml
<ItemGroup>
  <GoogleServicesJson Include="google-services.json" />
</ItemGroup>
```
 - add Android appliaction to your Firebase project & download **google-services.json** config file,
 - add **google-services.json** to your Android project and change **Build Action** to **GoogleServicesJson** in its properties.
 
 <table>
   <tr>
      <td>
         <img src="/screenshots/screenshot-android-1.png"/>
      </td>
      <td>
         <img src="/screenshots/screenshot-android-2.png"/>
      </td>
      <td>
         <img src="/screenshots/screenshot-android-3.png"/>
      </td>
   </tr>
</table>
  
### #4. Configure iOS project.
  - add [Xamarin.Firebase.iOS.Auth](https://www.nuget.org/packages/Xamarin.Firebase.iOS.Auth/) dependency using NuGet package manager,
  - create **FirebaseAuthentication** implementing **IFirebaseAuthentication** interface:
```c#
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
```
  - initialize Firebase in AppDelegate.cs by adding `Firebase.Core.App.Configure();`:
```c#
using Foundation;
using UIKit;

namespace FirebaseAuthenticationApp.iOS
{
	[Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            Firebase.Core.App.Configure();

            return base.FinishedLaunching(app, options);
        }
    }
}

```
 - add iOS appliaction to your Firebase project & download **GoogleService-Info.plist** config file,
 - add **GoogleService-Info.plist** to your iOS project and change **Build Action** to **BundleResource** in its properties.
 
<table>
   <tr>
      <td>
         <img src="/screenshots/screenshot-ios-1.png"/>
      </td>
      <td>
         <img src="/screenshots/screenshot-ios-2.png"/>
      </td>
      <td>
         <img src="/screenshots/screenshot-ios-3.png"/>
      </td>
   </tr>
</table>

### 4. Check if app is working using the code below.
```c#
IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();

// Register.
string token = await auth.RegisterWithEmailPassword(Email, Password);

// Login.
string token = await auth.LoginWithEmailPassword(Email, Password);
```

