using FirebaseAdmin.Messaging;
using FirebaseCloudMessaging.Models;

namespace FirebaseCloudMessaging.Services
{
    public class FirebaseMessagingService
    {
        public async Task<BatchResponse> SendPushNotification(FirebaseMessage firebaseMessage)
        {
            MulticastMessage message = new()
            {
                Tokens = firebaseMessage.Tokens,
                Notification = new Notification
                {
                    Body = firebaseMessage.Notification?.Body,
                    Title = firebaseMessage.Notification?.Title,
                    ImageUrl = firebaseMessage.Notification?.ImageUrl
                },
                Webpush = new WebpushConfig
                {
                    Notification = new WebpushNotification
                    {
                        Icon = firebaseMessage.Notification?.Icon,
                        // Actions = new List<FirebaseAdmin.Messaging.Action>() {
                        //     new FirebaseAdmin.Messaging.Action() {
                        //         ActionName = "Click",
                        //         Title = "OK"
                        //     }
                        // }                       
                    },
                    FcmOptions = new WebpushFcmOptions
                    {
                        Link = firebaseMessage.Notification?.Link
                    }
                },
                Data = firebaseMessage.Notification?.Data
            };

            BatchResponse response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message).ConfigureAwait(true);
            if (response.FailureCount > 0)
            {
                Console.WriteLine(response.ToString());
            }
            return response;
        }
    }
}
