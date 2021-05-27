using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Models;
using static WebAPI.MessageHandlers.ConversationOnMessageAdded;

namespace WebAPI.MessageHandlers
{
    public class ConversationOnMessageAdded : IRequestHandler<Request>
    {
        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            //TODO: React to the Call back from Twilio.
            return await Unit.Task;
        }

        public class Request : IRequest
        {
            public Request(ConversationOnMessageAddedResource conversationOnMessageAdded)
            {
                ConversationOnMessageAdded = conversationOnMessageAdded;
            }

            public ConversationOnMessageAddedResource ConversationOnMessageAdded { get; }
        }
    }
}