using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Google;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class FirebaseManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference dbReference;
    private GoogleSignInConfiguration configuration;

    public Text statusText;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
            dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        });

        configuration = new GoogleSignInConfiguration
        {
            WebClientId = "YOUR_WEB_CLIENT_ID",
            RequestIdToken = true
        };
    }

    public void GoogleSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleSignIn);
    }

    private void OnGoogleSignIn(Task<GoogleSignInUser> task)
    {
        if (task.IsCanceled || task.IsFaulted)
        {
            Debug.LogError("Google Sign-In failed.");
            statusText.text = "Google Sign-In failed.";
        }
        else
        {
            GoogleSignInUser user = task.Result;
            Firebase.Auth.Credential credential = GoogleAuthProvider.GetCredential(user.IdToken, null);
            auth.SignInWithCredentialAsync(credential).ContinueWith(OnFirebaseAuth);
        }
    }

    private void OnFirebaseAuth(Task<FirebaseUser> task)
    {
        if (task.IsCanceled || task.IsFaulted)
        {
            Debug.LogError("Firebase Auth failed.");
            statusText.text = "Firebase Auth failed.";
        }
        else
        {
            FirebaseUser newUser = task.Result;
            Debug.Log("User signed in successfully: " + newUser.DisplayName);
            statusText.text = "User signed in: " + newUser.DisplayName;
        }
    }

    public void SaveData(string userId, string data)
    {
        dbReference.Child("users").Child(userId).SetRawJsonValueAsync(data).ContinueWith(task => {
            if (task.IsCompleted)
            {
                statusText.text = "Data saved successfully.";
            }
            else
            {
                statusText.text = "Failed to save data.";
            }
        });
    }

    public void LoadData(string userId)
    {
        dbReference.Child("users").Child(userId).GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                statusText.text = snapshot.GetRawJsonValue();
            }
            else
            {
                statusText.text = "Failed to load data.";
            }
        });
    }
}
