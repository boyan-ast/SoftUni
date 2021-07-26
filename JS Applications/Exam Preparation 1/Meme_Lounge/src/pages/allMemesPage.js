import { html } from "../../node_modules/lit-html/lit-html.js";
import memesService from '../services/memesService.js';

let singleMemeTemplate = (meme) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${meme.title}</p>
            <img class="meme-image" alt="meme-img" src="${meme.imageUrl}">
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${meme._id}">Details</a>
        </div>
    </div>
</div>
`;

let allMemesTemplate = (allMemes) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        <!-- Display : All memes in database ( If any ) -->
        ${allMemes.length > 0 ?
        html`${allMemes.map(m => singleMemeTemplate(m))}` :
        html`<p class="no-memes">No memes in database.</p>`               
        }
    </div>
</section>`;

async function getView(context) {
    //TODO: try catch
    let allMemes = await memesService.getAll();
    console.log(allMemes);

    let result = allMemesTemplate(allMemes);

    context.renderView(result);
}

export default {
    getView
}