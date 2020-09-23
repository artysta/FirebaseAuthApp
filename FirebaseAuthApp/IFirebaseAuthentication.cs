using System.Threading.Tasks;

namespace FirebaseAuthApp
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> RegisterWithEmailPassword(string email, string password);
    }
}