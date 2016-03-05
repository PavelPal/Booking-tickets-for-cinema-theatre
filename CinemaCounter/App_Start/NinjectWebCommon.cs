using System;
using System.Web;
using CinemaCounter.App_Start;
using CinemaCounter.Models.Cinema;
using CinemaCounter.Models.DAO.Actor;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Company;
using CinemaCounter.Models.DAO.Director;
using CinemaCounter.Models.DAO.Genre;
using CinemaCounter.Models.DAO.Scene;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.DAO.Ticket;
using CinemaCounter.Models.Home;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace CinemaCounter.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
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
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICinemaDao>().To<CinemaDao>();
            kernel.Bind<ISceneDao>().To<SceneDao>();
            kernel.Bind<ITicketDao>().To<TicketDao>();
            kernel.Bind<IActorDao>().To<ActorDao>();
            kernel.Bind<ICompanyDao>().To<CompanyDao>();
            kernel.Bind<IDirectorDao>().To<DirectorDao>();
            kernel.Bind<ISessionDao>().To<SessionDao>();
            kernel.Bind<IGenreDao>().To<GenreDao>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<ICinemaService>().To<CinemaService>();
        }
    }
}