using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Base;
using Twilio.Exceptions;
using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;
using WebAPI.Models;
using WebAPI.Wrappers;
using static WebAPI.MessageHandlers.ConversationStart;

namespace WebAPI.MessageHandlers
{
    public class ConversationStart : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;

        public ConversationStart(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var conversation = (await _mediator.Send(new ConversationCreate.Request()))?.Resource;
            try
            {
                // Add a participant to the conversation
                await _mediator.Send(new ConversationAddSMSParticipant
                    .Request(conversation.Sid, request.FromPhoneNumber, request.ToPhoneNumber));
            }
            catch (ApiException ex)
            {
                switch (ex.MoreInfo)
                {
                    //The conversation for this from and to number already exists. Get the existing conversation.
                    case TwilioErrorCodes.E50416:
                        var conversationSid = ex.Message.Substring(ex.Message.Length - 34, 34);
                        conversation = (await _mediator.Send(new ConversationFetch.Request(conversationSid)))?.Resource;
                        break;
                    default:
                        throw;
                }
            }

            // Add a message to the conversation.
            await _mediator.Send(new ConversationAddMessage.Request(conversation.Sid, request.Message));

            // Ge the list of messages for this conversation.
            var messages = (await _mediator.Send(new ConversationFetchMessages.Request(conversation.Sid, 20)))?.Resources;

            // Ge the list of participant for this conversation.
            var participants = (await _mediator.Send(new ConversationFetchParticipants.Request(conversation.Sid, 20)))?.Resources;

            // return the Conversation, participant and Messages object.
            return await Task.FromResult(new Response { 
                Conversation = conversation,
                Messages = messages,
                Participants = participants
            });
        }


        public class Request : IRequest<Response>
        {
            public Request(PhoneNumber fromPhoneNumber, PhoneNumber toPhoneNumber, string message)
            {
                ToPhoneNumber = toPhoneNumber;
                FromPhoneNumber = fromPhoneNumber;
                Message = message;
            }

            public PhoneNumber ToPhoneNumber { get; }
            public PhoneNumber FromPhoneNumber { get; }
            public string Message { get; }
        }

        public class Response
        {
            public ConversationResource Conversation { get; set; }
            public ResourceSet<ParticipantResource> Participants { get; set; }
            public ResourceSet<MessageResource> Messages { get; set; }
        }
    }
}