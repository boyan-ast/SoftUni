import { html } from '../../node_modules/lit-html/lit-html.js';

import memesService from '../services/memesService.js';
import notificationPage from './notificationPage.js';

let editPageTemplate = (form) => html`
<section id="edit-meme">
    <form @submit="${form.onSubmit}" id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${form.meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">
                           ${form.meme.description}
                        </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${form.meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

async function getView(context) {
    let id = context.params.id;

    try {
        let meme = await memesService.getOne(id);

        let form = {
            meme,
            onSubmit
        };

        let result = editPageTemplate(form);

        context.renderView(result);

        async function onSubmit(e) {
            e.preventDefault();

            let formData = new FormData(e.currentTarget);

            let errorMessages = [];

            let title = formData.get('title');
            let description = formData.get('description');
            let imageUrl = formData.get('imageUrl');

            if (title == '') {
                errorMessages.push('Title is required!');
            }
            if (description == '') {
                errorMessages.push('Description is required!');
            }
            if (imageUrl == '') {
                errorMessages.push('ImageUrl is required!');
            }
    
            if (errorMessages.length > 0) {
                notificationPage.getNotification(errorMessages.join('\n'));
                return;
            }

            let editedMeme = {
                title,
                description,
                imageUrl
            };

            let response = await memesService.update(editedMeme, id);

            context.page.redirect(`/details/${meme._id}`);
        }

    } catch (error) {
        alert(error.message);
    }

}

export default {
    getView
}