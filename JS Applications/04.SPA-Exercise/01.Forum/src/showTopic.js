let commentForm = document.getElementById('comment-form');

export async function showTopic(e) {
    e.preventDefault();

    if (e.target.tagName == 'H2') {
        document.querySelector('.theme-content').classList.remove('hidden');
        let elementTitle = e.target.closest('.topic-name-wrapper').dataset.title;

        document.querySelector('.new-topic-border').classList.add('hidden');
        document.querySelector('#all-topics').classList.add('hidden');
        loadComments(elementTitle);

        commentForm.addEventListener('submit', addComment);       
    }
}

async function addComment(e) {
    e.preventDefault();

    let commentFormData = new FormData(commentForm);
    let title = document.querySelector('.theme-name h2').textContent;

    let postText = commentFormData.get('postText');
    let username = commentFormData.get('username');
    
    let currentdate = new Date();
    let day = currentdate.getDate();
    let month = (currentdate.getMonth() + 1);
    let year = currentdate.getFullYear();
    let hour = currentdate.getHours();
    let minutes = currentdate.getMinutes() < 10 ? '0' : '' + currentdate.getMinutes();
    var datetime = `${day}/${month}/${year} ${hour}:${minutes}`;

    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            text: postText,
            username: username,
            topic: title,
            datetime
        })
    });

    document.getElementById('answer-comment').value = '';
    document.getElementById('answer-username').value = '';

    loadComments(title);
}

async function loadComments(title) {
    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    let data = await response.json();
    let comments = Object.values(data);
    
    let selectedComments = comments.filter(c => c.topic == title);

    renderComments(selectedComments);
}

function renderComments(comments) {
    let firstComment = comments.shift();
    
    let topicTitle = document.querySelector('.theme-name-wrapper .theme-name h2');
    topicTitle.textContent = firstComment.topic;

    console.log(firstComment);

    document.getElementById('first-comment-username').textContent = firstComment.username;
    document.getElementById('first-comment-content').textContent = firstComment.text;    
    document.getElementById('first-comment-time').textContent = firstComment.datetime;    

    let templateCommentElement = document.getElementById('user-comment-template');
    
    let commentsDivElement = document.querySelector('.comment');
    let fragment = document.createDocumentFragment();
    Array.from(commentsDivElement.children).slice(2).forEach(el => el.remove());

    comments.forEach(c => {
        let commentElement = templateCommentElement.cloneNode(true);
        commentElement.classList.remove('hidden');

        let usernameElement = commentElement.querySelector('.topic-name p strong');
        usernameElement.textContent = c.username;
        let postContentElement = commentElement.querySelector('.post-content p');
        postContentElement.textContent = c.text;
        let timeElement = commentElement.querySelector('.topic-name p time');
        timeElement.textContent = c.datetime;

        fragment.appendChild(commentElement);
    });

    commentsDivElement.appendChild(fragment);
}