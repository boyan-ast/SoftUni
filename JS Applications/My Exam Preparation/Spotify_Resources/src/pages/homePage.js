import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let homePageTemplate = () => html`
<section id="homeView">
    <img class="m-auto background-image" width="100%" src="https://images.indianexpress.com/2020/05/spotify-bloom-1200.jpg">
</section>`;

function getView(context) {
    let result = homePageTemplate();

    context.renderView(result);
}

export default {
    getView
}