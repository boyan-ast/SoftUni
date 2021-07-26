import { html } from "../../node_modules/lit-html/lit-html.js";
import memesService from "../services/memesService.js";

let createTemplate = (form) => html`
<section id="create-meme">
    <form @submit="${form.onSubmit} "id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }

    let result = createTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);
        let title = formData.get('title');
        let description = formData.get('description');
        let imageUrl = formData.get('imageUrl');

        if (title == '' || description == '' || imageUrl == '') {
            window.alert('All fileds should be filled!');
            return;
        }

        //try - catch
        let response = await memesService.create({
            title,
            description,
            imageUrl
        });

        context.page.redirect('/allMemes');
    }
}

export default {
    getView
}