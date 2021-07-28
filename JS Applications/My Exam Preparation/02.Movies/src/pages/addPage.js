import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import moviesService from '../services/moviesService.js';

let addMoviePageTemplate = (form) => html`
<section id="add-movie">
    <form @submit="${form.onSubmit}" class="text-center border border-light p-5">
        <h1>Add Movie</h1>
        <div class="form-group">
            <label for="title">Movie Title</label>
            <input type="text" class="form-control" placeholder="Title" name="title" value="">
        </div>
        <div class="form-group">
            <label for="description">Movie Description</label>
            <textarea class="form-control" placeholder="Description" name="description"></textarea>
        </div>
        <div class="form-group">
            <label for="imageUrl">Image url</label>
            <input type="text" class="form-control" placeholder="Image Url" name="imageUrl" value="">
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }
    
    let result = addMoviePageTemplate(form);

    context.renderView(result);


    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let title = formData.get('title');
        let description = formData.get('description');
        let img = formData.get('imageUrl');

        if (title == '' || description == '' || img == '') {
            alert('All fields must be filled!');
            return;
        }

        let response = await moviesService.create({
            title,
            description,
            img
        });

        context.page.redirect('/home');
    }
}

export default {
    getView
}