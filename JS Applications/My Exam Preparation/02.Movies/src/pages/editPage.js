import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import moviesService from '../services/moviesService.js';

let editPageTemplate = (form) => html`
    <section id="edit-movie">
    <form @submit="${form.onSubmit}" class="text-center border border-light p-5">
        <h1>Edit Movie</h1>
        <div class="form-group">
            <label for="title">Movie Title</label>
            <input type="text" class="form-control" placeholder="Movie Title" .value=${form.movie.title} name="title">
        </div>
        <div class="form-group">
            <label for="description">Movie Description</label>
            <textarea class="form-control" placeholder="Movie Description..." name="description">${form.movie.description}</textarea>
        </div>
        <div class="form-group">
            <label for="imageUrl">Image url</label>
            <input type="text" class="form-control" placeholder="Image Url" .value=${form.movie.img} name="imageUrl">
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
    </section>`;

async function getView(context) {
    let movieId = context.params.id;
    let editedMovie = await moviesService.getOne(movieId);

    let form = {
        movie: editedMovie,
        onSubmit
    }
    
    let result = editPageTemplate(form);

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

        let response = await moviesService.update({
            title,
            description,
            img
        }, movieId);

        context.page.redirect('/home');
    }
}

export default {
    getView
}