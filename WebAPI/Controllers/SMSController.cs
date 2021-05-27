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
    [Route("WebAPI/SMS")]
    [ApiExceptionFilter]
    public class SMSController : ApiController
    {
        private readonly IMediator _mediator;

        public SMSController(ISMSClient client, IMediator mediator)
        {
            client.Init();
            _mediator = mediator;
        }
        
        [Route("SendSMS")]
        public async Task<IHttpActionResult> Send(string fromPhoneNumber, string toPhoneNumber, string message)
        {
            var result = await _mediator.Send(new SMSSend.Request(fromPhoneNumber, toPhoneNumber, message));
            return Json(result);
        }
    }
}