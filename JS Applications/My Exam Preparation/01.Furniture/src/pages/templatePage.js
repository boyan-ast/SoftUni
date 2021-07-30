import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let welcomePageTemplate = () => html`
`;

function getView(context) {
    let result = welcomePageTemplate();

    context.renderView(result);
}

export default {
    getView
}