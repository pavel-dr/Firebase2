using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
//using Firebase.Unity.Editor;
//using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//https://firebase.google.com/docs/database/unity/save-data?authuser=0
public class TestFirebase : MonoBehaviour
{


    public Text textOldGot;
    public Text textCur;
    public Text textGot;

    public string qweOldGot = "";
    public int qweCur = 0;
    public string qweGot = "";

    public Toggle toggle;
    //public bool dotliner;
    public bool Dotliner
    {
        set 
        {
            Debug.Log("k1=" + toggle.isOn);
            PlayerPrefs.SetInt("k1", toggle.isOn ? 1 : 0);
            //SetEditorDatabaseUrl();
        }
        get {
            Debug.Log("k1=" + (PlayerPrefs.GetInt("k1", 0) == 1));
            return PlayerPrefs.GetInt("k1", 0) == 1; 
        }
    }

    //public static FirebaseApp firebaseAppDL;
    //public static Firebase.FirebaseApp app;

    // Start is called before the first frame update
    void Start()
    {
        toggle.isOn = Dotliner;
        //SetEditorDatabaseUrl();
        // Set this before calling into the realtime database.


        //firebaseAppDL = new FirebaseApp()

        // Set these values before calling into the realtime database.

        //FirebaseApp.DefaultInstance.SetEditorP12FileName("YOUR-FIREBASE-APP-P12.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("SERVICE-ACCOUNT-ID@YOUR-FIREBASE-APP.iam.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");




        //Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        //{
        //    var dependencyStatus = task.Result;
        //    if (dependencyStatus == Firebase.DependencyStatus.Available)
        //    {
        //        // Create and hold a reference to your FirebaseApp,
        //        // where app is a Firebase.FirebaseApp property of your application class.
        //        app = Firebase.FirebaseApp.DefaultInstance;

        //        // Set a flag here to indicate whether Firebase is ready to use by your app.
        //    }
        //    else
        //    {
        //        UnityEngine.Debug.LogError(System.String.Format(
        //          "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
        //        // Firebase Unity SDK is not safe to use here.
        //    }
        //});

        //app.

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        //GetUser("UserId1", user1);
        //GetUser("UserId2", user2);
        //WriteNewUser(SystemInfo.deviceUniqueIdentifier, SystemInfo.deviceName, SystemInfo.deviceName+ "@gmail.com");
        GetQwe(true);

    }

    //public void WriteNewUser()
    //{
    //    WriteNewUser(SystemInfo.deviceUniqueIdentifier, SystemInfo.deviceName, SystemInfo.deviceName + "@gmail.com");
    //}


    //private void WriteNewUser(string userId, string name, string email)
    //{
    //    User user = new User(name, email);
    //    string json = JsonUtility.ToJson(user);
    //    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    //    reference.Child("users").Child(userId).SetRawJsonValueAsync(json);

    //    //DatabaseReference reference2 = FirebaseDatabase.DefaultInstance.RootReference;
    //    //reference2.Child("users").Child(userId).SetRawJsonValueAsync(json);
    //    //reference.Child("users").Child(userId).Child("username").SetValueAsync(name);

    //}
    DataSnapshot snapshot;
    //private void GetUser(string userId, User user)
    //{
    //    FirebaseDatabase.DefaultInstance
    //        .GetReference("users").Child(userId)
    //        .GetValueAsync().ContinueWith(task => {
    //            if (task.IsFaulted)
    //            {
    //                Debug.LogError(task.Exception.Message);
    //                     // Handle the error...
    //            }
    //            else if (task.IsCompleted)
    //            {
    //                snapshot = task.Result;
    //                Debug.Log(task.Result.GetValue(true));
    //                Debug.Log(task.Result.GetValue(false));
                    
    //                //Debug.Log(snapshot.Value.ToString());
    //                foreach (var a in (Dictionary<string, object>)snapshot.Value)
    //                {
    //                    Debug.Log(a.Key + "=" + a.Value);
    //                }

    //                user = JsonUtility.FromJson<User>(snapshot.Value.ToString());
    //                     // Do something with snapshot...
    //            }
    //        });


    //    //reference.Child("users").Child(userId).Child("username").SetValueAsync(name);

    //}
    //private void Update()
    //{
    //    if (snapshot != null)
    //    {
    //        Debug.Log(snapshot.Value.ToString());
    //    }
    //}

    
    public void UpdateQweValue()
    {
        GetQwe(true);


        qweCur += 1;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("qwe").SetValueAsync(qweCur);

        GetQwe(false);
        //textOld.text=

    }


    private void GetQwe(bool old)
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("qwe")
            .GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Debug.LogError(task.Exception.Message);
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    snapshot = task.Result;
                    Debug.Log(snapshot.GetValue(true));
                    if (old) {
                        qweOldGot = snapshot.GetValue(true).ToString();
                    }
                    else
                    {
                        qweGot = snapshot.GetValue(true).ToString();
                    }
                }
            });


        //reference.Child("users").Child(userId).Child("username").SetValueAsync(name);

    }

    public void Update()
    {
        textOldGot.text = qweOldGot.ToString();
        textCur.text = qweCur.ToString();
        textGot.text = qweGot.ToString();
    }

    //public void SetEditorDatabaseUrl()
    //{
    //    //Firebase.FirebaseApp.
    //    //if (Dotliner)
    //    //{
    //    //    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dotliner-70536380.firebaseio.com/");
    //    //}
    //    //else
    //    //{
    //    //    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testproject-neatappsse.firebaseio.com/");
    //    //}
    //}


}
