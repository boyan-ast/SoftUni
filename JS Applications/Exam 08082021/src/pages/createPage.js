import { html } from '../../node_modules/lit-html/lit-html.js';

import booksService from '../services/booksService.js';

let createPageTemplate = (form) => html`
<!-- Create Page ( Only for logged-in users ) -->
<section id="create-page" class="create">
    <form @submit="${form.onSubmit}" id="create-form" action="" method="">
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
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

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let title = formData.get('title');
        let description = formData.get('description');
        let imageUrl = formData.get('imageUrl');

        let selectElement = formElement.querySelector('#type');
        let type = selectElement.value;

        if (title == '' || description == '' || imageUrl == '') {
            alert('All fields must be filled!');
            return;
        }
        
        let newBook = {
            title,
            description,
            imageUrl,
            type
        };

        try {
            let response = await booksService.createBook(newBook);
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}