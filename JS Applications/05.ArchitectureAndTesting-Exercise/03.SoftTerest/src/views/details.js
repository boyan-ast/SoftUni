import { createElement } from "../createElement.js";

export function setupDetails(section, navigation) {
    return showDetails;

    async function showDetails(id) {
        section.innerHTML = '';

        let response = await fetch(`http://localhost:3030/data/ideas/${id}`);
        let ideaInfo = await response.json();
        let card = createIdeaCard(ideaInfo);
        section.appendChild(card);

        return section;
    }

    function createIdeaCard(idea) {
        let result = document.createDocumentFragment();

        let imgElement = createElement('img', { class: 'det-img', src: idea.img });

        let mainDivElement = createElement('div', { class: 'desc' });

        mainDivElement.innerHTML = `
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>`;

        let aElement = createElement('a', { class: 'btn detb', href: "" }, 'Delete');
        let divBtnElement = createElement('div', { class: 'text-center' }, aElement);

        aElement.addEventListener('click', (e) => deleteIdea(e, idea._id));

        result.appendChild(imgElement);
        result.appendChild(mainDivElement);

        if (sessionStorage.getItem('userId') == idea._ownerId) {
            result.appendChild(divBtnElement);
        }

        return result;
    }

    async function deleteIdea(e, id) {
        e.preventDefault();

        let deleteResponse = await fetch(`http://localhost:3030/data/ideas/${id}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': sessionStorage.authToken
            }
        });

        if (deleteResponse.ok) {
            navigation.goTo('dashboard');
        } else {
            console.error('Error!');
        }
    }
}

