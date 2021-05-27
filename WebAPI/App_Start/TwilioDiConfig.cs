using Autofac;
using Autofac.Core;
using System.Configuration;
using Twilio.Clients;
using WebAPI.Wrappers;

namespace WebAPI.App_Start
{
    public class TwilioDiConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var accountSid = ConfigurationManager.AppSettings["Twilio:AccountSid"];
            var authToken = ConfigurationManager.AppSettings["Twilio:AuthToken"];
            builder.Register(c => new SMSClient(accountSid, authToken))
                .AsSelf().AsImplementedInterfaces().SingleInstance();
        }
    }
}