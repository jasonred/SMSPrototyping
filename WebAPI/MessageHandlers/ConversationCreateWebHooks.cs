using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Rest.Conversations.V1.Conversation;
using static WebAPI.MessageHandlers.ConversationCreateWebHooks;

namespace WebAPI.MessageHandlers
{
    public class ConversationCreateWebHooks : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response {
                Resource = WebhookResource.Create(request.ConversationSid, WebhookResource.TargetEnum.Webhook,
                configurationUrl: request.Url, configurationFilters: request.Filters)
            });
        }

        public class Request : IRequest<Response>
        {
            public Request(string conversationSid, string url, List<string> filters)
            {
                ConversationSid = conversationSid;
                Url = url;
                Filters = filters;
            }

            public List<string> Filters { get; }
            public string Url { get; }
            public string ConversationSid { get; }
        }

        public class Response
        {
            public WebhookResource Resource { get; set; }
        }
    }

}