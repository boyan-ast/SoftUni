import { html } from '../../node_modules/lit-html/lit-html.js';

import petsService from '../services/petsService.js';

let editPageTemplate = (form) => html`
<section class="detailsMyPet">
    <h3>${form.pet.name}</h3>
    <p class="img"><img
            src="${form.pet.imageUrl}"></p>
    <form @submit="${form.onSubmit}">
        <textarea type="text" name="description">${form.pet.description}</textarea>
        <button class="button"> Save</button>
    </form>
</section>`;

async function getView(context) {
    let id = context.params.id;

    let pet = await petsService.getOne(id);

    let form = {
        onSubmit,
        pet
    }

    let result = editPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e){
        e.preventDefault();
        let invalidData = [];

        let formData = new FormData(e.currentTarget);
        let description = formData.get('description');

        if (description.length < 3) {
            invalidData.push('Description lenght must be at least 3 symbols!');
        }

        if (invalidData.length > 0) {
            alert(invalidData.join('\n'));
            return;
        }

        pet.description = description;

        let response = await petsService.update(pet, id);
        
        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}