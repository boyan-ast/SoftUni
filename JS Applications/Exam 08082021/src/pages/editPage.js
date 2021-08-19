import { html } from '../../node_modules/lit-html/lit-html.js';

import booksService from '../services/booksService.js';

let editPageTemplate = (form, book) => html`
<!-- Edit Page ( Only for the creator )-->
<section id="edit-page" class="edit">
    <form @submit="${form.onSubmit}" id="edit-form" action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value="${book.title}">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value="${book.imageUrl}">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value="${book.type}">
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>`;

async function getView(context) {
    let id = context.params.id;
    let book = undefined;

    try {
        book = await booksService.getBook(id);
    } catch (error) {
        alert(error.message);
        return;
    }

    let form = {
        onSubmit
    };

    let result = editPageTemplate(form, book);

    context.renderView(result);

    async function onSubmit(e) {
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

        let editedBook = {
            title,
            description,
            imageUrl,
            type
        };

        try {
            let response = await booksService.updateBook(editedBook, id);
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}