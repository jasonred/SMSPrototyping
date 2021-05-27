using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Rest.Conversations.V1.Conversation;
using WebAPI.Wrappers;
using static WebAPI.MessageHandlers.ConversationAddMessage;

namespace WebAPI.MessageHandlers
{
    public class ConversationAddMessage : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response
            {
                Resource = MessageResource.Create(
                    body: request.Message,
                    pathConversationSid: request.ConversationSid
                )
            });
        }

        public class Request : IRequest<Response>
        {
            public Request(string conversationSid, string message)
            {
                ConversationSid = conversationSid;
                Message = message;
            }

            public string ConversationSid { get; }
            public string Message { get; }
        }

        public class Response
        {
            public MessageResource Resource { get; set; }
        }
    }

}