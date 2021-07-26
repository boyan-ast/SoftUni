import { html } from "../../node_modules/lit-html/lit-html.js";
import memesService from "../services/memesService.js";

let editTemplate = (form) => html`
<section id="edit-meme">
    <form @submit="${form.submitHandler} "id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${form.meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">
                                    ${form.meme.description.trim()}
                                </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${form.meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

async function getView(context) {
    let id = context.params.id;

    let existingMeme = await memesService.getOne(id);

    let form = {
        meme: existingMeme,
        submitHandler
    }

    let result = editTemplate(form);
    context.renderView(result);

    async function submitHandler(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let title = formData.get('title');
        let description = formData.get('description').trim();
        let imageUrl = formData.get('imageUrl');

        if (title == '' || description == '' || imageUrl == '') {
            window.alert('All fields are required!');
            return;
        }
        //try catch
        let response = await memesService.update({title, description, imageUrl}, id);
        context.page.redirect(`/details/${id}`);
    }
}


export default {
    getView
}
