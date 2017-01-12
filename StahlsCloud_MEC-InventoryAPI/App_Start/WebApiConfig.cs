using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StahlsCloud_MEC_InventoryAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "StahlsCloud/{controller}/{business_unit}/{business_item_id}",
                defaults: new { business_unit = RouteParameter.Optional , business_item_id = RouteParameter.Optional }
                
            );
        }
    }
}
