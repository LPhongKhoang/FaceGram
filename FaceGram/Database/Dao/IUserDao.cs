using FaceGram.Database.EF;
using FaceGram.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface IUserDao
    {
        string insert(User user);

        char isExistUser(string email, string password);

        User getByEmail(string email);

        User getUserByEmailPass(string email, string password);

        string getUserName(string uid);

        User getUserByID(string id);

        List<User> getListUser();

        IQueryable<User> getUsersExcept(string id);

        void editUserProfile(UserProfileModel userProfileModel, string uid);
        List<User> getAllFriends(string id);

        string getRole(string userId);

        void insertRole(Role role);
        List<User> getAllUnFollowUsers(string userId);

        User getUserByPostId(string postId);
        IQueryable<User> searchUserByUsername(string textSearch, string loginedUserId);
    }
}
