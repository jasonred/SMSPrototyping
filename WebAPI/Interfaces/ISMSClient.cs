using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Interfaces
{
    public interface ISMSClient
    {
        string AccountSid { get; }
        string AuthToken { get; }
        string WebHookBaseUrl { get; }
        bool IsTestEnvironment { get; }
        void Init();
    }

}