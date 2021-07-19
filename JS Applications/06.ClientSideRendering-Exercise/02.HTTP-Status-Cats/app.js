import { cats } from './catSeeder.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';

let liTemplate = (catInfo) => html`
<li>
    <img src="./images/${catInfo.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="${catInfo.id}">
            <h4>Status Code: ${catInfo.statusCode}</h4>
            <p>${catInfo.statusMessage}</p>
        </div>
    </div>
</li>`;

let ulTemplate = html`
<ul @click=${showInfo}>
    ${cats.map(liTemplate)}
</ul>`;

let catsSection = document.getElementById('allCats');

render(ulTemplate, catsSection);

function showInfo(e) {
    let clickedElement = e.target;

    if (clickedElement.nodeName == 'BUTTON') {
        let hiddenDivElement = clickedElement.nextElementSibling;

        hiddenDivElement.style.display = hiddenDivElement.style.display == 'block' ? 'none' : 'block';
        clickedElement.textContent = clickedElement.textContent.startsWith('Show') ? 'Hide status code' : 'Show status code';
    }
}