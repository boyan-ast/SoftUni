import { renderTopic } from "./renderTopic.js";

export async function loadTopics() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    let topicsInfo = await response.json();

    Object.values(topicsInfo).forEach(t => {
        renderTopic(t.title, t.username, t.datetime);
    });
}