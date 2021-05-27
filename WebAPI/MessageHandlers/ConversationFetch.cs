using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Twilio.Rest.Conversations.V1;

using static WebAPI.MessageHandlers.ConversationFetch;

namespace WebAPI.MessageHandlers
{
    public class ConversationFetch : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response
            {
                Resource = ConversationResource.Fetch(request.ConversationSid)
            });
        }

        public class Request : IRequest<Response>
        {
            public Request(string conversationSid)
            {
                ConversationSid = conversationSid;
            }

            public string ConversationSid { get; }
        }

        public class Response
        {
            public ConversationResource Resource { get; set; }
        }
    }
}