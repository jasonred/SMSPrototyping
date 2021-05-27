using Autofac;
using Autofac.Core;
using System;
using System.Configuration;
using Twilio.Clients;
using WebAPI.Wrappers;

namespace WebAPI.App_Start
{
    public class TwilioDiConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SMSClient
            {
                AccountSid = ConfigurationManager.AppSettings["Twilio:AccountSid"], 
                AuthToken = ConfigurationManager.AppSettings["Twilio:AuthToken"], 
                WebHookBaseUrl = ConfigurationManager.AppSettings["Twilio:WebHookBaseUrl"],
                IsTestEnvironment = Convert.ToBoolean(ConfigurationManager.AppSettings["Twilio:IsTestEnvironment"])
            }).AsSelf().AsImplementedInterfaces().SingleInstance();
        }
    }
}