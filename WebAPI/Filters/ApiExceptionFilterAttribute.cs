using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPI.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext context)
        //{
        //    if (context.Exception is HttpException ex)
        //    {
        //        var httpStatusCode = (HttpStatusCode)ex.GetHttpCode();
        //        context.Response = new HttpResponseMessage(httpStatusCode)
        //        {
        //            Content = new StringContent(ex.Message),
        //            ReasonPhrase = ex.Message
        //        };
        //    }
        //}
    }
}