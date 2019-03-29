$(document).ready(() => {
    // Toggle click on image.icon-like 
    $(".icon-like").off("click").on("click", (e) => {
       
        e.preventDefault();

        let iconLike = $(e.target);
        
        let postId = iconLike.data("postid");

        $.ajax({
            url: "/PostInteract/Like",
            data: { postId: postId },
            type: "Post",
            dataType: "json",
            success: (response) => {
                if (response.status === true) {
                    iconLike.attr("src", "/Assets/Images/web_icon/favorite-liked.PNG");
                    
                } else {
                    iconLike.attr("src", "/Assets/Images/web_icon/favorite.PNG");
                }
                iconLike.next().text(response.showLiked);
                
            },
            error: (response) => {
                alert('woops: Ajax faild');
            }

        });
    });




    // Enter text to input#addComment -> Post is active
    $("input.addComment").keyup((e) => {
        let inputText = $(e.target);
        let btnAddComment = inputText.next();
        let text = inputText.val().trim();    
        if (text !== "") {
            enableBtnAddComment(btnAddComment);
        } else {
            disableBtnAddComment(btnAddComment);
        }
    });



    //Add comment 
    $(".btnAddComment").click((e) => {
        let btnAddComment = $(e.target);
        let inputText = btnAddComment.prev();
        requestAddComment(inputText, btnAddComment);

    });

    $("input.addComment").keyup((e) => {
        // Check if User press Enter
        if (e.keyCode === 13) {
            let inputText = $(e.target);
            let btnAddComment = inputText.next();
            requestAddComment(inputText, btnAddComment);
        }
    });

});


function addNewComment(response) {
    let postId = response.postId;
    let idCommentContainer = "#post-comments-" + postId;
    let commentContainer = $(idCommentContainer);
    let newDivCommentStr = `<div class='comment'>
                                <img class='img-responsive img-circle' src = '${response.user.Avatar}' />
                                <a href='#' class='nickname'>${response.user.UserName}</a>
                                <span class='text-comment'>${response.text}</span>
                            </div >`;
    commentContainer.append(newDivCommentStr);
    
}

function requestAddComment(inputText, btnAddComment) { 
    let postId = inputText.data("postid");
    let text = inputText.val().trim();

    if (text !== "") {
        $.ajax({
            url: "/PostInteract/Comment",
            data: { postId: postId, text: text },
            type: "Post",
            dataType: "json",
            success: (response) => {
                console.log(response);
                if (response.status === true) {
                    addNewComment(response);
                    inputText.val("");
                    disableBtnAddComment(btnAddComment);
                } else {
                    alert('Comment failed!');
                }


            },
            error: (response) => {
                alert('woops: Ajax faild');
            }

        });
    }
}

function disableBtnAddComment(btnAddComment) {
    btnAddComment.css({ "color": "#b7bac5", "font-weight": "100" });
    btnAddComment.hover(() => { btnAddComment.css("cursor", "context-menu"); },
        () => { btnAddComment.css("cursor", "context-menu") }
    );
}

function enableBtnAddComment(btnAddComment) {
    btnAddComment.css({ "color": "#4d5d98", "font-weight": "bold" });
    btnAddComment.hover(() => { btnAddComment.css("cursor", "pointer"); },
        () => { btnAddComment.css("cursor", "context-menu") }
    );
}