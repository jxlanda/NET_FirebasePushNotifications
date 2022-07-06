# FirebaseCloudMessaging

The Admin SDK is a set of server libraries that lets you interact with Firebase from privileged environments to perform actions like:

* Read and write Realtime Database data with full admin privileges.
* Programmatically send Firebase Cloud Messaging messages using a simple, alternative approach to the Firebase Cloud Messaging server protocols.
* Generate and verify Firebase auth tokens.
* Access Google Cloud resources like Cloud Storage buckets and Cloud Firestore databases associated with your Firebase projects.
* Create your own simplified admin console to do things like look up user data or change a user's email address for authentication.

## Initialize the SDK

Once you have created a Firebase project, you can initialize the SDK with an authorization strategy that combines your service account file together with Google Application Default Credentials.

Firebase projects support Google service accounts, which you can use to call Firebase server APIs from your app server or trusted environment. If you're developing code locally or deploying your application on-premises, you can use credentials obtained via this service account to authorize server requests.

To authenticate a service account and authorize it to access Firebase services, you must generate a private key file in JSON format.

To generate a private key file for your service account:

* In the Firebase console, open Settings > Service Accounts.

* Click Generate New Private Key, then confirm by clicking Generate Key.

* Securely store the JSON file containing the key.

When authorizing via a service account, you have two choices for providing the credentials to your application. You can either set the `GOOGLE_APPLICATION_CREDENTIALS` environment variable, or you can explicitly pass the path to the service account key in code. The first option is more secure and is strongly recommended.

### To set the environment variable:

Set the environment variable `GOOGLE_APPLICATION_CREDENTIALS` to the file path of the JSON file that contains your service account key. This variable only applies to your current shell session, so if you open a new session, set the variable again.

PoweShell:

    $env:GOOGLE_APPLICATION_CREDENTIALS="C:\Users\username\Downloads\service-account-file.json"

After you've completed the above steps, Application Default Credentials (ADC) is able to implicitly determine your credentials, allowing you to use service account credentials when testing or running in non-Google environments.

Initialize the SDK as shown:

    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.GetApplicationDefault(),
    });

More info:
 * https://firebase.google.com/docs/admin/setup/#linux-or-macos
