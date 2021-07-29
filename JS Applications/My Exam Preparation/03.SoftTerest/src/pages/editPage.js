import { html } from '../../node_modules/lit-html/lit-html.js';
import ideasService from '../services/ideasService.js';

let editPageTemplate = (form) => html`
<div class="container home wrapper  my-md-5 pl-md-5">
    <div class=" d-md-flex flex-mb-equal ">
        <div class="col-md-6">
            <img class="responsive-ideas create" src="./images/creativity_painted_face.jpg" alt="">
        </div>
        <form @submit="${form.onSubmit}" class="form-idea col-md-5">
            <div class="text-center mb-4">
                <h1 class="h3 mb-3 font-weight-normal">Share Your Idea</h1>
            </div>
            <div class="form-label-group">
                <label for="ideaTitle">Title</label>
                <input type="text" id="title" name="title" class="form-control" placeholder="What is your idea?"
                    required="" autofocus="" .value="${form.idea.title}">
            </div>
            <div class="form-label-group">
                <label for="ideaDescription">Description</label>
                <textarea type="text" name="description" class="form-control" placeholder="Description"
                    required="">${form.idea.description}</textarea>
            </div>
            <div class="form-label-group">
                <label for="inputURL">Add Image</label>
                <input type="text" id="imageURl" name="imageURL" class="form-control" placeholder="Image URL"
                    required="" .value="${form.idea.img}">

            </div>
            <button class="btn btn-lg btn-dark btn-block" type="submit">Edit</button>

            <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2021.</p>
        </form>
    </div>
</div>`;

async function getView(context) {
    let id = context.params.id;

    let idea = await ideasService.getOne(id);

    let form = {
        idea,
        onSubmit
    };

    let result = editPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let title = formData.get('title');
        let description = formData.get('description');
        let img = formData.get('imageURL');

        if (title.length < 6 || description.length < 10 || img.length < 5) {
            alert('Invalid input!');
            return;
        }

        let editedIdea = {
            title,
            description,
            img
        }

        try {
            let response = await ideasService.update(editedIdea, id);
            formElement.reset();
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(`${error.message}`);
        }
    }
}

export default {
    getView
}