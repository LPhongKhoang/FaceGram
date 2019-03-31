/*
/// 2: mean logined User and this User is friend: Friend
/// 1: mean logined User is following this User: Following
/// 0: mean no relationship between logined User and this User: Fan/Follow Back
/// -1: mean logined User is followed by this User: Follow
*/
const REL_FRIEND = "Friend";
const REL_FOLLOWING = "Following";
const REL_FAN = "Fan/Follow Back";
const REL_FOLLOW = "Follow";


$(document).ready(()=>{
    // Handle event click follow/unfollow
    $(".btn-follow").click((e) => {
        let btnFollow = $(e.target);

        let userId = btnFollow.data("userid");

        $.ajax({
            url: "/Relationship/Follow",
            data: { friendId: userId },
            type: "Post",
            dataType: "json",
            success: (response) => {
                let relationShipStatus = response.relationshipStatus;
                showBtnFollow(relationShipStatus, btnFollow);
                
            },
            error: (response) => {
                alert('woops: Ajax faild');
            }

        });

    });
});

function showBtnFollow(relationshipStatus, btnFollow) {
    switch(relationshipStatus){
        case REL_FRIEND:
            btnFollow.removeClass("btn-danger");
            btnFollow.addClass("btn-success");
            
        break;
            
        case REL_FOLLOWING:
            btnFollow.removeClass("btn-default");
            btnFollow.addClass("btn-info");
        break;

        case REL_FAN:
            btnFollow.removeClass("btn-success");
            btnFollow.addClass("btn-danger")
        break;
            
        default:
            btnFollow.removeClass("btn-info");
            btnFollow.addClass("btn-default")


    }

    btnFollow.text(relationshipStatus); 
}