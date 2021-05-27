using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebAPI.App_Start
{
    public class MediatrDiConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(MediatrDiConfig).Assembly);
        }
    }
}