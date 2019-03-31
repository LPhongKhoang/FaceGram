using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Service
{
    public interface INewFeedService
    {
        /// <summary>
        /// get info about Posts and Other unfollowed user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NewFeedModel getNewFeedModel(string id);

        /// <summary>
        /// Get Posts to display in newfeed Of current logined user
        /// </summary>
        /// <param name="id">id of current logined user</param>
        /// <returns></returns>
        List<PostModel> getPostModelsForNewFeed(string id);

        
    }
}
