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
            container.RegisterSingleton<IPostDao, PostDao>();
            container.RegisterSingleton<IRelationshipDao, RelationshipDao>();
            container.RegisterSingleton<ITestService, TestService>();
            container.RegisterSingleton<IUserService, UserService>();
            container.RegisterSingleton<IProfileService, ProfileService>();
            container.RegisterSingleton<IRelationshipService, RelationshipService>();
            container.RegisterSingleton<IEditProfileService, EditProfileService>();
            container.RegisterSingleton<ILogoutService, LogoutService>();
            container.RegisterSingleton<IAdminService, AdminService>();
            container.RegisterSingleton<ICommentDao, CommentDao>();
            container.RegisterSingleton<IFavoriteDao, FavoriteDao>();
            container.RegisterSingleton<INewFeedService, NewFeedService>();
            container.RegisterSingleton<IPostInteractService, PostInteractService>();
            container.RegisterSingleton<IAddAccountService, AddAccountService>();
        }
    }
}