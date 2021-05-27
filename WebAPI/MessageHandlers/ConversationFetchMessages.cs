using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Base;
using Twilio.Rest.Conversations.V1.Conversation;
using static WebAPI.MessageHandlers.ConversationFetchMessages;

namespace WebAPI.MessageHandlers
{
    public class ConversationFetchMessages : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response {
                Resources = MessageResource.Read(
                    pathConversationSid: request.ConversationSid,
                    limit: request.Limit
                )
            });
        }

        public class Request : IRequest<Response>
        {
            public Request(string conversationSid, int limit)
            {
                ConversationSid = conversationSid;
                Limit = limit;
            }

            public string ConversationSid { get; }
            public int Limit { get; }
        }

        public class Response
        {
            public ResourceSet<MessageResource> Resources { get; set; }
        }
    }

}

