using System.Threading.Tasks;
using Firebase.Auth;
using InputCentar.Models;

namespace InputCentar.Data
{
    public class DatabaseService
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public DatabaseService()
        {
            // Initialize Firebase Authentication provider
            _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBxOUDFDWHXLX-CJZXq2AF3xHHZn-TJ2rA"));
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            try
            {
                // Authenticate user with Firebase Authentication
                var authResult = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(username, password);

                // If authentication is successful, create a new User object
                var user = new User
                {
                    Username = username,
                    // Add any additional user properties you want to populate from Firebase
                };

                return user;
            }
            catch (FirebaseAuthException)
            {
                // If authentication fails, return null
                return null;
            }
        }
    }
}
