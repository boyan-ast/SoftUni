import { html } from '../../node_modules/lit-html/lit-html.js';

import authService from '../services/authService.js';
import petsService from '../services/petsService.js';
import { singlePetTemplate } from './shared/singlePetTemplate.js';

let myPetsPageTemplate = (myPets) => html`
 <section class="my-pets">
    <h1>My Pets</h1>
    <ul class="my-pets-list">
        ${myPets.map(p => singlePetTemplate(p))}
    </ul>
</section>`;

async function getView(context) {
    let myPets = await petsService.getMyPets(authService.getUserId());

    let result = myPetsPageTemplate(myPets);

    context.renderView(result);
}

export default {
    getView
}