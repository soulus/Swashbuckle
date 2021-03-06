﻿using System.Web.Mvc;
using System.Web.Routing;
using Swashbuckle.Handlers;

namespace Swashbuckle
{
    public class SwaggerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Swagger"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapRoute(
                "Swagger_index",
                "swagger/api-docs",
                new {controller = "ApiDocs", action = "Index"});

            context.Routes.MapRoute(
                "Swagger_show",
                "swagger/api-docs/{resourceName}",
                new { controller = "ApiDocs", action = "Show" });

            context.Routes.Add(new Route(
                "swagger",
                new RedirectRouteHandler("swagger/ui/index.html")));

            context.Routes.Add(new Route(
                "swagger/ui/{*path}",
                new SwaggerUiRouteHandler()));
        }
    }
}