let topicContainerElement = document.querySelector('.topic-container');

export function renderTopic(title, username, datetime) {
    let templateElement = document.getElementById('template-topic');
    
    let newTopicElement = templateElement.cloneNode(true);
    newTopicElement.classList.remove('hidden');
    newTopicElement.removeAttribute('id');
    newTopicElement.dataset.title = title;

    let h2TitleElement = newTopicElement.querySelector('a h2.topic-title');
    h2TitleElement.textContent = title;
    
    let currentTime = datetime;
    let timeElement = newTopicElement.querySelector('.columns div p time');
    timeElement.textContent = currentTime;
    let pUsernameElement = newTopicElement.querySelector('.nick-name p span');
    pUsernameElement.textContent = username;

    topicContainerElement.appendChild(newTopicElement);
}

