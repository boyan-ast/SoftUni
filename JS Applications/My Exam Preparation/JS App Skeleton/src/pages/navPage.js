import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn) => html`
${isLoggedIn ? 
    html`
        ` :
    html`
       `
}`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();

    let result = navPageTemplate(isLoggedIn);

    context.renderNav(result);

    next();
}

export default {
    getView
}