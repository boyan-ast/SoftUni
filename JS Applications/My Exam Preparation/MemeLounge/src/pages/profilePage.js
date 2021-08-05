import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memesService from '../services/memesService.js';

let singleMemeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
    <a class="button" href="/details/${meme._id}">Details</a>
</div>`;

let profilePageTemplate = (allMemes) => html`
<!-- Profile Page ( Only for logged users ) -->
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${authService.getGender()}.png">
        <div class="user-content">
            <p>Username: ${authService.getUsername()}</p>
            <p>Email: ${authService.getEmail()}</p>
            <p>My memes count: ${allMemes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        ${allMemes.length > 0 ? 
        allMemes.map(m => singleMemeTemplate(m)) : 
        html`<p class="no-memes">No memes in database.</p>`}
    </div>
</section>`;

async function getView(context) {
    try {
        let myMemes = await memesService.getMyObjects(authService.getUserId());

        let result = profilePageTemplate(myMemes);

        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }


}

export default {
    getView
}