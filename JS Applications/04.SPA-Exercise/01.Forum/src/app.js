import { loadTopics } from './loadTopics.js';
import { postTopic } from './homeEvents.js';
import { cancelPost } from './homeEvents.js';
import { showTopic } from './showTopic.js';
import { renderHomePage} from './homeEvents.js';

loadTopics();

let postButton = document.querySelector('#new-topic-form .new-topic-buttons .public');
let cancelButton = postButton.previousElementSibling;

document.querySelector('.theme-content').classList.add('hidden');

postButton.addEventListener('click', postTopic);
cancelButton.addEventListener('click', cancelPost);

let allTopicsElement = document.getElementById('all-topics');

allTopicsElement.addEventListener('click', showTopic);

let homeAElement = document.getElementById('home-page');

homeAElement.addEventListener('click', renderHomePage);