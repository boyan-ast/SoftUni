import {html} from '../../../node_modules/lit-html/lit-html.js';

export let singlePetTemplate = (pet) => html`
<li class="otherPet">
    <h3>Name: ${pet.name}</h3>
    <p>Category: ${pet.category}</p>
    <p class="img"><img src="${pet.imageUrl}"></p>
    <p class="description">${pet.description}</p>
    <div class="pet-info">
        <a href="/details/${pet._id}"><button class="button">Details</button></a>
    </div>
</li>`;
