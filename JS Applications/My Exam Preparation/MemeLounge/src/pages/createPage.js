import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memesService from '../services/memesService.js';
import notificationPage from './notificationPage.js';

let createPageTemplate = (form) => html`
<section id="create-meme">
    <form @submit="${form.onSubmit}" id="create-form">
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
    };

    let result = createPageTemplate(form);

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

        try {
            let newMeme = {
                title,
                description,
                imageUrl
            };

            let res = await memesService.create(newMeme);

            context.page.redirect('/all-memes');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}