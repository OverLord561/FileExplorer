﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AprioritFoldersTask.Mapping;
using AprioritFoldersTask.Models;
using AutoMapper;

namespace AprioritFoldersTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public Type FoldersViewModel { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            UnityConfig.RegisterComponents();
            Mapper.Initialize(x =>
            {
                x.AddProfile<FoldersMappingProfile>();
            });

        }
        protected void Application_Error()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
                /* When the request is ajax the system can automatically handle a mistake with a JSON response. 
                   Then overwrites the default response */
                if (requestContext.HttpContext.Request.IsAjaxRequest())
                {
                    httpContext.Response.Clear();
                    string controllerName = requestContext.RouteData.GetRequiredString("controller");
                    IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                    IController controller = factory.CreateController(requestContext, controllerName);
                    ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                    JsonResult jsonResult = new JsonResult
                    {
                        Data = new { success = false, serverError = "500" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult.ExecuteResult(controllerContext);
                    httpContext.Response.End();
                }
                else
                {
                    httpContext.Response.Redirect("/Home/Error");
                }
            }
        }
    }
}
