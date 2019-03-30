using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Database.EF;

namespace FaceGram.Service
{
    public interface IAddAccountService
    {
        void insertAccount(User u);

        void insertRole(Role role);

        bool emailExisted(string email);

        bool phonelExisted(string phone);
    }
}
