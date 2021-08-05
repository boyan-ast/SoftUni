import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memesService from '../services/memesService.js';

let detailsPageTemplate = (meme, onDeleteClick) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}
    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src="${meme.imageUrl}">
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>
            ${authService.getUserId() == meme._ownerId ? 
                html`
                <a class="button warning" href="/edit/${meme._id}">Edit</a>
                <button @click="${onDeleteClick}" class="button danger">Delete</button>` : ''}
        </div>
    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;

    let meme = await memesService.getOne(id);
    let result = detailsPageTemplate(meme, onDeleteClick);

    context.renderView(result);

    async function onDeleteClick(e) {
        let confirmed = confirm('Are you sure?');

        if (confirmed) {
            await memesService.deleteOne(id);
            context.page.redirect('/all-memes');
        }
    }
}

export default {
    getView
}