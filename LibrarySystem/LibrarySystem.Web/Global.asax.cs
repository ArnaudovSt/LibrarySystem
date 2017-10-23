using System;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LibrarySystem.Common;
using LibrarySystem.Data;
using LibrarySystem.Data.Migrations;
using LibrarySystem.Web.App_Start;

namespace LibrarySystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemDbContext, MigrationsConfiguration>());

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mapper = new AutoMapperConfig();
            mapper.Execute(Assembly.GetExecutingAssembly());
        }

        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg.Equals(GlobalConstants.CacheVaryByCustom, StringComparison.InvariantCultureIgnoreCase))
            {
                return context.User.Identity.Name;
            }

            return base.GetVaryByCustomString(context, arg);
        }
    }
}
