const defaultImage = "/Assets/Images/image_post/default.png";

$(document).ready(()=>{
    $("#inputPostContent").keyup((e) => {
        let inputPostContent = $("#inputPostContent");
        let postContent = inputPostContent.val();
        // Enable post button when has text 
        if(postContent.trim().length > 0){
            $("#btnUploadPost").removeAttr("disabled");
        }else{
            $("#btnUploadPost").attr("disabled", "disabled");
        }

        // Set font-size of textarea suitable with length of input text
        if (postContent.length >= 100) {
            inputPostContent.css("font-size", "18px");
        } else {
            inputPostContent.css("font-size", "25px");
        }
    });

    // Handle event when user choose file from computer
    $("#inputPostImage").change((e) => {
        let inputPostImage = $("#inputPostImage")[0];
        showImagePreview(inputPostImage);
          
    });


    // Use Ajax to upload a Post
    $("#form-upload-post").submit((e) => {
        e.preventDefault(); // avoid to execute the actual submit of the form.

        let form = $("#form-upload-post");    

        let inputPostContent = $("#inputPostContent");
        let inputPostImage = $("#inputPostImage")[0];

        let postContent = inputPostContent.val().trim();

        // check post content is empty
        if (postContent === "") {
            return;
        }

        let postImage = null;
        if (inputPostImage.files) {
            postImage = inputPostImage.files[0];
        }


        let data = new FormData;
        data.append("postContent", postContent);
        data.append("postImage", postImage);

        let url = "/PostInteract/CreatePost";
        
        $.ajax({
            url: url,
            data: data,
            type: "Post",
            contentType: false,
            processData: false,
            success: (data) => {
                resetUploadPost();
                addNewPost(data);
                
            },
            error: () => {
                alert("Upload post error");
            }
        });

    });
});

function addNewPost(data) {
    let newfeedsContainer = $("#newfeeds");

    let imagePostStr = data.imagePath === defaultImage ? "" : `<img class="img-responsive" src="${data.imagePath}" />`;

    let newPostStr = `<div class="post-basic">
                        <div class="post-header post-align-side">
                            <div class="avatar-name pull-left">
                                <img class="img-responsive img-circle" src="${data.user.Avatar}" />
                                <a href="#" class="nickname">${data.user.UserName}</a>
                            </div>
                            <div class="time-ago pull-right">
                                <span></span>
                            </div>
                        </div>
                        <div class="post-content post-align-side">
                            <p>${data.postContent}</p>

                        </div>
                        <div class="post-image">
                            ${imagePostStr}
                        </div>
                        <div class="post-interact post-align-side">
                            <div class="post-like">
                                <img class="img-responsive icon-like" width="25" data-postid="${data.postId}"
                                        src='/Assets/Images/web_icon/favorite.PNG' />
                                <span></span>
                            </div>
                            <div class="post-comments" id='post-comments-${data.postId}'>                              

                            </div>
                        </div>
                        <div class="add-comment">
                            <div class="input-group">
                                <input class="addComment" type="text" placeholder="Write a comment" data-postid="${data.postId}" aria-describedby="basic-addon2">
                                <span class="input-group-addon btnAddComment">Post</span>
                            </div>

                        </div>
                    </div>`;

    newfeedsContainer.prepend(newPostStr);


}

function resetUploadPost() {
    $('#uploadPostModel').modal('toggle');
    $('#form-upload-post').trigger("reset");
    $('#show-img').removeAttr("src");
}

function showImagePreview(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        let imgFile = input.files[0];
        reader.readAsDataURL(imgFile);

        reader.onload = function (e) {
            $('#show-img').attr('src', e.target.result);
        }
    }
}