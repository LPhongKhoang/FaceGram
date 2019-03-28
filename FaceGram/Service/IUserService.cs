using FaceGram.Database.EF;
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
    }
}
