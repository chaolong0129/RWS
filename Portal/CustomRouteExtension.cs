using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public static class CustomRouteExtension
    {
        public static IRouteBuilder AddCustomRoute(this IRouteBuilder routeBuilder, IApplicationBuilder app)
        {
            routeBuilder.Routes.Add(
                new Route(new CustomRoute(), 
                "products/{lang:regex(^([a-z]{{2}})-([A-Z]{{2}})$)}/{category:alpha}/{subcategory:alpha}/{id:guid}",
                app.ApplicationServices.GetService(typeof(IInlineConstraintResolver)) as IInlineConstraintResolver)
                );

            return routeBuilder;
        }
    }
}
