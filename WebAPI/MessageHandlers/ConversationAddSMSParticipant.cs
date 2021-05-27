using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Exceptions;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;
using WebAPI.Models;
using WebAPI.Wrappers;
using static WebAPI.MessageHandlers.ConversationAddSMSParticipant;

namespace WebAPI.MessageHandlers
{
    public class ConversationAddSMSParticipant : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response
            {
                Resource = ParticipantResource.Create(
                    messagingBindingAddress: request.ToPhoneNumber.ToString(),
                    messagingBindingProxyAddress: request.FromPhoneNumber.ToString(),
                    pathConversationSid: request.ConversationSid)
            });
        }

        public class Request : IRequest<Response>
        {
            public Request(string conversationSid, PhoneNumber fromPhoneNumber, PhoneNumber toPhoneNumber)
            {
                ConversationSid = conversationSid;
                ToPhoneNumber = toPhoneNumber;
                FromPhoneNumber = fromPhoneNumber;
            }

            public string ConversationSid { get; }
            public PhoneNumber ToPhoneNumber { get; }
            public PhoneNumber FromPhoneNumber { get; }
        }

        public class Response
        {
            public ParticipantResource Resource { get; set; }
        }
    }

}