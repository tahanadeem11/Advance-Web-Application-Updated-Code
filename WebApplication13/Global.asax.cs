using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication13.Models;
namespace WebApplication13
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()

        {
            Database.SetInitializer<WebApplication13.Models.EmpContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
