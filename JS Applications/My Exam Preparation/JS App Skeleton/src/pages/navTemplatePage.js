import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = () => html`
${authService.isLoggedIn() ? 
    html`
        ` :
    html`
       `
}`;

function getView(context, next) {

    let result = navPageTemplate();

    context.renderNav(result);

    next();
}

export default {
    getView
}