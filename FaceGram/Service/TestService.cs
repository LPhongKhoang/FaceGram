using FaceGram.Database.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class TestService : ITestService
    {
        private IUserDao userDao;
        public TestService(IUserDao userDao)
        {
            this.userDao = userDao;
        }
        public string sayHello()
        {
            return "Hello Phong khoang pro";
        }
    }
}