using System.Data.Entity;
using LibrarySystem.Data.UnitOfWork;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LibrarySystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LibrarySystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace LibrarySystem.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using LibrarySystem.Data;
    using LibrarySystem.Data.Repositories;
    using System.Reflection;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            //kernel.Bind(x =>
            //{
            //    x.From(Assembly.GetAssembly(CommonServicesAssemblyType).FullName,
            //            Assembly.GetAssembly(DataServicesAssemblyType).FullName
            //            )
            //        .SelectAllClasses()
            //        .BindDefaultInterface();
            //});

            kernel.Bind(typeof(DbContext), typeof(LibrarySystemDbContext)).To<LibrarySystemDbContext>()
                .InRequestScope();
            kernel.Bind(typeof(IEfRepostory<>)).To(typeof(EfRepostory<>)).InRequestScope();
            kernel.Bind<IEfUnitOfWork>().To<EfUnitOfWork>().InRequestScope();
        }
    }
}
