import { renderTopic } from "./renderTopic.js";

export async function postTopic(e) {
    e.preventDefault();
    let newTopicForm = e.currentTarget.closest('#new-topic-form');
    let formData = new FormData(newTopicForm);

    let title = formData.get('topicName');
    let username = formData.get('username');
    let content = formData.get('postText');

    let currentdate = new Date();
    let day = currentdate.getDate();
    let month = (currentdate.getMonth() + 1);
    let year = currentdate.getFullYear();
    let hour = currentdate.getHours();
    let minutes = currentdate.getMinutes() < 10 ? '0' : '' + currentdate.getMinutes();
    var datetime = `${day}/${month}/${year} ${hour}:${minutes}`;

    if (title == '' || username == '' || content == '') {
        return;
    }

    let newTopicObj = {
        title,
        username,
        datetime
    };

    let response = fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newTopicObj)
    });

    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';

    renderTopic(title, username, datetime);

    addComment(content, username, title, datetime);
}

export function cancelPost(e) {
    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';
}

export function renderHomePage(e) {
    document.querySelector('.new-topic-border').classList.remove('hidden');
    document.querySelector('#all-topics').classList.remove('hidden');
    document.querySelector('.theme-content').classList.add('hidden');
}

async function addComment(postText, username, elementTitle, datetime) {
    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            text: postText,
            username: username,
            topic: elementTitle,
            datetime
        })
    });
}