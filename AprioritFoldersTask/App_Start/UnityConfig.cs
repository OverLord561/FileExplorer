using AprioritFoldersTask.Repositories;
using AprioritFoldersTask.Repositories.EntityFramework;
using AprioritFoldersTask.Services;
using AprioritFoldersTask.Services.Interfaces;
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
            container.RegisterType<IFoldersService, FoldersService>();
            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}