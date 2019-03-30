using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.EF;

namespace FaceGram.Database.Dao
{
    public class RelationshipDao : IRelationshipDao
    {
        FaceGramDbContext dbContext;

        public RelationshipDao(FaceGramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int getNumberUserFollow(string uid)
        {
            int numberUserFollow = dbContext.Relationships.Count(x => x.fId.Equals(uid));

            return numberUserFollow;
        }

        public int getNumberRelationship(string uid)
        {
            int numberUserFollow = dbContext.Relationships.Count(x => x.id.Equals(uid));

            return numberUserFollow;
        }

        public List<Relationship> getAllRelationship()
        {
            var listRela = dbContext.Relationships.ToList();

            return listRela;
        }

        public void deleteRelationshipByID(string idRela)
        {
            var deleteRela = dbContext.Relationships.SingleOrDefault(x => x.id == idRela);

            dbContext.Relationships.Remove(deleteRela);
            dbContext.SaveChanges();
        }
    }
}