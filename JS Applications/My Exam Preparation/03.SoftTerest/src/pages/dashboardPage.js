import { html } from '../../node_modules/lit-html/lit-html.js';
import ideasService from '../services/ideasService.js';

let singeIdeaTemplate = (idea) => html`
<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a class="btn" href="/details/${idea._id}">Details</a>
</div>`;

let dashboardPageTemplate = (allIdeas) => html`
<div id="dashboard-holder">
    ${allIdeas.length > 0 ?
    html`${allIdeas.map(i => singeIdeaTemplate(i))}`: 
    html`<h1>No ideas yet! Be the first one :)</h1>`}    
</div>`;

async function getView(context) {
    try {
        let allIdeas = await ideasService.getAll();
        let result = dashboardPageTemplate(allIdeas);
        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}