import { html } from '../../node_modules/lit-html/lit-html.js';

import petsService from '../services/petsService.js';
import { singlePetTemplate } from './shared/singlePetTemplate.js';

let dashboardPageTemplate = (allPets) => html`
<section class="dashboard">
    <h1>Dashboard</h1>
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
    let allPets = await petsService.getAll();

    let result = dashboardPageTemplate(allPets);

    context.renderView(result);
}

export default {
    getView
}