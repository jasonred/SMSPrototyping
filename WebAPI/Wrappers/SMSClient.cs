using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Types;
using WebAPI.Interfaces;

namespace WebAPI.Wrappers
{
    public class SMSClient : ISMSClient
    {

        public void Init()
        {
            TwilioClient.Init(AccountSid, AuthToken);
        }

        public string WebHookBaseUrl { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public bool IsTestEnvironment { get; set; }

    }
}