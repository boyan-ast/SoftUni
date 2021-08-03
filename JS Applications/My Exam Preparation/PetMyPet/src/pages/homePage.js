import { html } from '../../node_modules/lit-html/lit-html.js';

let homePageTemplate = () => html`
<section class="basic">
    <h1> Welcome to pet my pet!</h1>
</section>`;

function getView(context) {
    let result = homePageTemplate();

    context.renderView(result);
}

export default {
    getView
}