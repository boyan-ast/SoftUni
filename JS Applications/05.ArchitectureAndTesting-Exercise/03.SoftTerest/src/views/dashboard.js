import { createElement } from '../createElement.js';

export function setupDashboard(section, navigation) {
    section.addEventListener('click', (e) => {
        if (e.target.classList.contains('btn')) {
            e.preventDefault();
            let ideaId = e.target.id;
            navigation.goTo('details', ideaId);
        }
    });

    return showDashboard;

    async function showDashboard() {
        section.innerHTML = '';

        let response = await fetch('http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
        let ideas = await response.json();

        if (ideas.length == 0) {
            section.innerHTML = '<h1>No ideas yet! Be the first one :)</h1>';
        } else {
            let cards = ideas.map(createIdeaPreview);
            cards.forEach(c => section.appendChild(c));
        }

        return section;
    }
}

function createIdeaPreview(idea) {
    let element = createElement('div', { class: 'card overflow-hidden current-card details'});
    element.style = 'width: 20rem; height: 18rem;';

    element.innerHTML = `  
<div class="card-body">
    <p class="card-text">${idea.title}</p>
</div>
<img class="card-image" src="${idea.img}" alt="Card image cap">
<a id="${idea._id}" class="btn" href="">Details</a>`;

    return element;
}