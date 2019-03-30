using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Database.EF;

namespace FaceGram.Database.Dao
{
    public interface IRelationshipDao
    {
        int getNumberUserFollow(string uid);

        int getNumberRelationship(string uid);

        List<Relationship> getAllRelationship();

        void deleteRelationshipByID(string idRela);
    }
}
