using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Service;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FaceGram
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
         
            registerServices(container);
                        
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void registerServices(UnityContainer container)
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterSingleton<FaceGramDbContext>();
            container.RegisterSingleton<IUserDao, UserDao>();
            container.RegisterSingleton<ITestService, TestService>();
        }
    }
}