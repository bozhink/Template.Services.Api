namespace Application.Web.Api
{
    using System;
    using System.Web;

    using Common.Providers;

    using Data;
    using Data.Repositories;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
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

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<ApplicationDbContext>();

            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind<IRandomProvider>().To<RandomProvider>();
        }
    }
}