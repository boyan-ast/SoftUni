import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import petsService from '../services/petsService.js';

let detailsPageTemplate = (pet, onDeleteClick) => html`
<section class="myPet">
    <h3>Name: ${pet.name}</h3>
    <p>Category: ${pet.category}</p>
    <p class="img"><img src="${pet.imageUrl}"></p>
    <p class="description">${pet.description}</p>
    <div class="pet-info">
        ${authService.currentUserIsOwner(pet._ownerId) ? 
        html`
        <a href="/edit/${pet._id}"><button class="button">Edit</button></a>
        <a @click="${onDeleteClick}" href="javascript:void(0)"><button class="button">Delete</button></a>`:
        ''}
    </div>`;

async function getView(context) {
    let id = context.params.id;

    let pet = await petsService.getOne(id);

    let result = detailsPageTemplate(pet, onDeleteClick);

    context.renderView(result);

    async function onDeleteClick(e){
        e.preventDefault();

        await petsService.deleteOne(id);

        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}