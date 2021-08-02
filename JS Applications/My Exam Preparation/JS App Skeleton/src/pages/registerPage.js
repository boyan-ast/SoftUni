import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let registerPageTemplate = (form) => html`
`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = registerPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
    }
}

export default {
    getView
}