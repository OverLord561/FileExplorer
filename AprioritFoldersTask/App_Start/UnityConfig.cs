using AprioritFoldersTask.Repositories;
using AprioritFoldersTask.Repositories.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AprioritFoldersTask
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFoldersRepository, FoldersRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}