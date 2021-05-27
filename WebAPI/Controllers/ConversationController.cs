using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Twilio.Types;
using WebAPI.Filters;
using WebAPI.MessageHandlers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("WebAPI/Conversation")]
    [ApiExceptionFilter]
    public class ConversationController : ApiController
    {
        private readonly IMediator _mediator;
        public ConversationController(ISMSClient client, IMediator mediator)
        {
            client.Init();
            _mediator = mediator;
        }

        [Route("StartConversation")]
        public async Task<IHttpActionResult> StartConversation(string fromPhoneNumber, string toPhoneNumber, string message)
        {
            var result = await _mediator.Send(new ConversationStart.Request(fromPhoneNumber, toPhoneNumber, message));
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

        //[Route("AddSMSParticipant")]
        //public async Task<IHttpActionResult> AddSMSParticipant(string conversationSid, string fromPhoneNumber, string toPhoneNumber)
        //{
        //    var result = await _mediator.Send(new ConversationAddSMSParticipant.Request(conversationSid, fromPhoneNumber, toPhoneNumber));
        //    return Json(result);
        //}

        //[Route("FetchConversation")]
        //public async Task<IHttpActionResult> FetchConversation(string conversationSid)
        //{
        //    var result = await _mediator.Send(new ConversationFetch.Request(conversationSid));
        //    return Json(result);
        //}

    }
}