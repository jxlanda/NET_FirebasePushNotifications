using FirebaseAdmin.Messaging;
using FirebaseCloudMessaging.Models;
using FirebaseCloudMessaging.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseCloudMessaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseController : ControllerBase
    {
        private IConfiguration _config;
        private FirebaseMessagingService _messagingService;

        public FirebaseController(IConfiguration config, FirebaseMessagingService messagingService)
        {
            _config = config;
            _messagingService = messagingService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FirebaseMessage firebaseMessage)
        {
            var response = await _messagingService.SendPushNotification(firebaseMessage);

            return Ok(response);
        }

    }
}
