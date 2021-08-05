import { html, render } from '../../node_modules/lit-html/lit-html.js';

let notificationPageTemplate = (message) => html`
<div id="errorBox" class="notification">
    <span>${message}</span>
</div>`;

function getNotification(message) {
    let result = notificationPageTemplate(message);

    let notificationElement = document.getElementById('notifications');

    render(result, notificationElement);

    setTimeout(() => {notificationElement.innerHTML = ''}, 3000);
}

export default {
    getNotification
}