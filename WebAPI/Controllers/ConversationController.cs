using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Interfaces;
using WebAPI.MessageHandlers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("WebAPI/Conversation")]
    public class ConversationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ISMSClient _client;
        public ConversationController(ISMSClient client, IMediator mediator)
        {
            client.Init();
            _client = client;
            _mediator = mediator;
        }

        [Route("StartConversation")]
        public async Task<IHttpActionResult> StartConversation(string fromPhoneNumber, string toPhoneNumber, string message)
        {
            var result = await _mediator.Send(new ConversationStart.Request(fromPhoneNumber, toPhoneNumber, message, _client.WebHookBaseUrl));
            return Json(result);
        }
        [Route("CloseConversation")]
        public async Task<IHttpActionResult> CloseConversation(string conversationSid)
        {
            var result = await _mediator.Send(new ConversationClose.Request(conversationSid));
            return Json(result);
        }
        [Route("AddMessage")]
        public async Task<IHttpActionResult> AddMessage(string conversationSid, string message)
        {
            var result = await _mediator.Send(new ConversationAddMessage.Request(conversationSid, message));
            return Json(result);
        }
        [Route("FetchMessages")]
        public async Task<IHttpActionResult> FetchMessages(string conversationSid)
        {
            var result = await _mediator.Send(new ConversationFetchMessages.Request(conversationSid, 20));
            return Json(result);
        }

        [Route("OnMessageAdded")]
        [ValidateTwilioRequestImproved]
        public async Task<IHttpActionResult> OnMessageAdded(ConversationOnMessageAddedResource resource)
        {
            var result = await _mediator.Send(new ConversationOnMessageAdded.Request(resource));
            return Json(result);
        }
    }
}