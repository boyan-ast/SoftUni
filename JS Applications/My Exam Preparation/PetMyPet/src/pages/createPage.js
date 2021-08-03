import { html } from '../../node_modules/lit-html/lit-html.js';

import petsService from '../services/petsService.js';

let createPageTemplate = (form) => html`
<section class="create">
    <form @submit="${form.onSubmit}">
        <fieldset>
            <legend>Add new Pet</legend>
            <p class="field">
                <label for="name">Name</label>
                <span class="input">
                    <input type="text" name="name" id="name" placeholder="Name" />
                    <span class="actions"></span>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea rows="4" cols="45" type="text" name="description" id="description"
                        placeholder="Description"></textarea>
                    <span class="actions"></span>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageURL" id="image" placeholder="Image" />
                    <span class="actions"></span>
                </span>
            </p>
            <p class="field">
                <label for="category">Category</label>
                <span class="input">
                    <select type="text" name="category">
                        <option>Cat</option>
                        <option>Dog</option>
                        <option>Parrot</option>
                        <option>Reptile</option>
                        <option>Other</option>
                    </select>
                    <span class="actions"></span>
                </span>
            </p>
            <input class="button" type="submit" class="submit" value="Add Pet" />
        </fieldset>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = createPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e){
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let name = formData.get('name');
        let description = formData.get('description');
        let imageUrl = formData.get('imageURL');

        let selectElement = e.currentTarget.querySelector('select[name="category"]');
        let category = selectElement.value;

        let response = await petsService.create({
            name, description, imageUrl, category
        });

        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}