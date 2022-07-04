namespace FirebaseCloudMessaging.Models
{
    public partial class FirebaseMessage
    {
        public string[]? Tokens { get; set; }
        public FirebaseNotification? Notification { get; set; }
    }

    public partial class FirebaseNotification
    {
        public string? Body { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Icon { get; set; }
        public string? Link { get; set; }
        public Dictionary<string, string>? Data { get; set; } = new Dictionary<string, string>();
    }
}
