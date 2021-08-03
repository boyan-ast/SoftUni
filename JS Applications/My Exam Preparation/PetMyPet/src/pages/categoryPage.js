import { html } from '../../node_modules/lit-html/lit-html.js';

import petsService from '../services/petsService.js';

let singlePetTemplate = (pet) => html`
<li class="otherPet">
    <h3>Name: ${pet.name}</h3>
    <p>Category: ${pet.category}</p>
    <p class="img"><img src="${pet.imageUrl}"></p>
    <p class="description">${pet.description}</p>
    <div class="pet-info">
        <a href="/details/${pet._id}"><button class="button">Details</button></a>
    </div>
</li>`;

let dashboardPageTemplate = (allPets, category) => html`
<section class="dashboard">
    <h1>${category + 's'}</h1>
    <nav class="navbar">
        <ul>
            <li><a href="/dashboard">All</a></li>
            <li><a href="/category/cat">Cats</a></li>
            <li><a href="/category/dog">Dogs</a></li>
            <li><a href="/category/parrot">Parrots</a></li>
            <li><a href="/category/reptile">Reptiles</a></li>
            <li><a href="/category/other">Other</a></li>
        </ul>
    </nav>
    <ul class="other-pets-list">
        ${allPets.map(p => singlePetTemplate(p))}
    </ul>
</section>`;

async function getView(context) {
    let category = context.params.category;
    category = category.charAt(0).toUpperCase() + category.slice(1);

    let pets = await petsService.getByCategory(category);

    let result = dashboardPageTemplate(pets, category);

    context.renderView(result);
}

export default {
    getView
}