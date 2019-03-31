using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class RelationshipController : BaseUserController
    {
        private IRelationshipService relationshipService;

        public RelationshipController(IRelationshipService relationshipService)
        {
            this.relationshipService = relationshipService;
        }

        [HttpPost]
        public JsonResult Follow(string friendId)
        {
            string userId = getUserIdInSession();
            bool result = relationshipService.toggleFollow(userId, friendId);
            string relationshipStatus = relationshipService.getRelationship(userId, friendId);
            return Json(new {
                status = result,
                relationshipStatus
            });
        }

    }
}