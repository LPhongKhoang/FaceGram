using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Common;
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

        public bool toggleFollow(string userId, string friendId)
        {
            try
            {
                // Check if userId - friendId is a relationship
                int count = dbContext.Relationships.Count(x => x.uId == userId && x.fId == friendId);

                if (count >= 1)
                {
                    dbContext.Relationships.RemoveRange(dbContext.Relationships.Where(x => x.uId == userId && x.fId == friendId));

                }
                else
                {
                    Relationship newRelationship = new Relationship() { id = DateTimeUtils.getKeyTimeStamp(), uId = userId, fId = friendId };
                    dbContext.Relationships.Add(newRelationship);
                }

                dbContext.SaveChanges();
                return count < 1;
            }
            catch
            {
                return false;
            }


        }

        public string getRelationship(string userId, string friendId)
        {
            int count1 = dbContext.Relationships.Count(x => x.uId == userId && x.fId == friendId);
            int count2 = dbContext.Relationships.Count(x => x.uId == friendId && x.fId == userId);

            if(count1 >= 1 && count2 >= 1)
            {
                return CommonConstant.REL_FRIEND;
            }else if(count1 >= 1)
            {
                return CommonConstant.REL_FOLLOWING;
            }else if(count2 >= 1)
            {
                return CommonConstant.REL_FAN;
            }
            else
            {
                return CommonConstant.REL_FOLLOW;
            }
        }
    }
}