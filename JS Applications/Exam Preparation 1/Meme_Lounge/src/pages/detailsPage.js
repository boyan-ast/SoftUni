import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";
import memesService from "../services/memesService.js";

let detailsTemplate = (meme, deleteHandler) => html`
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

            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            ${meme._ownerId == authService.getUserId() ? 
            html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button @click="${deleteHandler}" class="button danger">Delete</button>` :
            ''
            }           

        </div>
    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;
    //try catch
    let meme = await memesService.getOne(id);

    let result = detailsTemplate(meme, deleteHandler);

    context.renderView(result);

    async function deleteHandler(e) {
        let confirmed = confirm('Are you sure?');

        if (confirmed) {
            await memesService.deleteItem(id);
            context.page.redirect('/allMemes');
        }
    }
    
}

export default {
    getView
}
