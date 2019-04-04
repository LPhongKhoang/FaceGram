using FaceGram.Database.EF;
using FaceGram.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Service
{
    public interface IUserService
    {
        char verifyAccount(string email, string password);

        User getByEmail(string email);

        string getRole(string userId);

        IPagedList<UserAvatarModel> getAllUserExcept(string userId, int page, int pageSize);
        IPagedList<UserAvatarModel> searchUserByUserName(string textSearch, string loginedUserId, int page, int pageSize);
    }
}
