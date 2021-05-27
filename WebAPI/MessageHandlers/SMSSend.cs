using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebAPI.Wrappers;
using static WebAPI.MessageHandlers.SMSSend;

namespace WebAPI.MessageHandlers
{
    public class SMSSend : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response{
                Resource = MessageResource.Create(
                to: request.ToPhoneNumber,
                from: request.FromPhoneNumber,
                body: request.Message) 
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
            public MessageResource Resource { get; set; }
        }

    }
}