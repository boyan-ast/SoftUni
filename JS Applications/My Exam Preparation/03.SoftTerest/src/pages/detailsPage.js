import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import ideasService from '../services/ideasService.js';

let detailsPageTemplate = (idea, userIsOwner, onDeleteClick) => html`
<div class="container home some">
    <img class="det-img" src="${idea.img}" />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>
    ${userIsOwner ? 
    html`
        <div class="text-center">
            <a class="btn detb" href="/edit/${idea._id}">Edit</a>
            <a class="btn detb" @click="${onDeleteClick}" href="javascript:void(0)">Delete</a>
        </div>` : ''}

</div>`;

async function getView(context) {
    let id = context.params.id;
    let idea = await ideasService.getOne(id);

    let userIsOwner = authService.currentUserIsOwner(idea._ownerId);

    let result = detailsPageTemplate(idea, userIsOwner, onDeleteClick);

    context.renderView(result);

    async function onDeleteClick(e) {
        e.preventDefault();

        try {
            let confirmed = confirm('Are you sure?');
            if(confirmed) {
                ideasService.deleteOne(id);
                context.page.redirect('/dashboard');
            }
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}