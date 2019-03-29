using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface IRelationshipDao
    {
        int getNumberUserFollow(string uid);

        int getNumberRelationship(string uid);
    }
}
