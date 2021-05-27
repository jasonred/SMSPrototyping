using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Exceptions;
using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;
using WebAPI.Models;
using WebAPI.Wrappers;
using static WebAPI.MessageHandlers.ConversationCreate;

namespace WebAPI.MessageHandlers
{
    public class ConversationCreate : IRequestHandler<Request, Response>
    {

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response { Resource = ConversationResource.Create() });
        }


        public class Request : IRequest<Response>
        {
        }

        public class Response
        {
            public ConversationResource Resource { get; set; }
        }
    }
}