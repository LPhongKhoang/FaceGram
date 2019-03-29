using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Database.EF;

namespace FaceGram.Database.Dao
{
    public interface IPostDao
    {
        int getNumberPostUser(string uid);

        List<Post> getCurrentUserPost(string uid);
    }
}
