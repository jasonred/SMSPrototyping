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

namespace WebAPI.Wrappers
{
    public interface ISMSClient 
    {
        //Dictionary<string, PhoneNumber> FromNumbers { get; }
        void Init();
    }
    public class SMSClient : ISMSClient
    {
        //public Dictionary<string, PhoneNumber> FromNumbers { get; }
        private string _accountSid;
        private string _authToken;
        public SMSClient(string accountSid, string authToken)
        //public SMSClient(string accountSid, string authToken, Dictionary<string, PhoneNumber> fromNumbers)
        {
            //FromNumbers = fromNumbers;
            _accountSid = accountSid;
            _authToken = authToken;
        }
        public void Init()
        {
            TwilioClient.Init(_accountSid, _authToken);
        }
    }
}