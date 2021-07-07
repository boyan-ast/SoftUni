function attachEvents() {
    let loadButtonElement = document.getElementById('btnLoadPosts');

    loadButtonElement.addEventListener('click', loadPosts);
}

function loadPosts(e) {
    fetch('http://localhost:3030/jsonstore/blog/posts')
        .then(response => response.json())
        .then(posts => {
            let selectPostsElement = document.getElementById('posts');
            Array.from(selectPostsElement.children).forEach(el => el.remove());

            let h1TitleElement = document.getElementById('post-title');
            h1TitleElement.textContent = 'Post Details';

            let pBodyElement = document.getElementById('post-body');
            pBodyElement.textContent = '';

            let ulCommentsElement = document.getElementById('post-comments');
            Array.from(ulCommentsElement.children).forEach(el => el.remove());

            Object.keys(posts).forEach(pKey => {
                let postTitle = posts[pKey].title;
                let optionElement = document.createElement('option');
                optionElement.value = pKey;
                optionElement.textContent = postTitle.toUpperCase();

                selectPostsElement.appendChild(optionElement);

                let viewButtonElement = document.getElementById('btnViewPost');

                viewButtonElement.addEventListener('click', viewPost)
            });
        })
        .catch(catchError);
}

function viewPost(e) {
    let selectElement = e.currentTarget.previousElementSibling;
    let postId = selectElement.value;

    let postUrl = `http://localhost:3030/jsonstore/blog/posts/${postId}`;

    fetch(postUrl)
        .then(response => response.json())
        .then(postObj => {
            let postTitle = postObj.title;
            let postContent = postObj.body;

            let h1TitleElement = document.getElementById('post-title');
            h1TitleElement.textContent = postTitle.toUpperCase();

            let pBodyElement = document.getElementById('post-body');
            pBodyElement.textContent = postContent;
        })
        .catch(catchError);

    fetch('http://localhost:3030/jsonstore/blog/comments')
        .then(response => response.json())
        .then(commentsObj => {
            let ulCommentsElement = document.getElementById('post-comments');
            Array.from(ulCommentsElement.children).forEach(el => el.remove());

            let commentsInfo = Object.values(commentsObj);
            let postComments = commentsInfo.filter(c => c.postId == postId);

            postComments.forEach(commentObj => {
                let comment = commentObj.text;

                let commentLiElement = document.createElement('li');
                commentLiElement.id = commentObj.id;
                commentLiElement.textContent = comment;

                ulCommentsElement.appendChild(commentLiElement);
            });
        })
        .catch(catchError);
}

function catchError(e) {
    let selectPostsElement = document.getElementById('posts');
    Array.from(selectPostsElement.children).forEach(el => el.remove());

    let h1TitleElement = document.getElementById('post-title');
    h1TitleElement.textContent = 'Error';

    let pBodyElement = document.getElementById('post-body');
    pBodyElement.textContent = '';

    let ulCommentsElement = document.getElementById('post-comments');
    Array.from(ulCommentsElement.children).forEach(el => el.remove());
}

attachEvents();