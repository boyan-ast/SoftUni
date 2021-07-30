import { html } from "../../node_modules/lit-html/lit-html.js";
import { ifDefined } from "../../node_modules/lit-html/directives/if-defined.js";

import authService from "../services/authService.js";

let navPageTemplate = (context) => html`
<h1><a href="/">Furniture Store</a></h1>
<nav>
    <a id="catalogLink" href="/dashboard" class="${ifDefined(context.path.endsWith('dashboard') ? 'active' : undefined)}">Dashboard</a>
${authService.isLoggedIn() ? 
    html`
    <div id="user">
        <a id="createLink" href="/create" class="${ifDefined(context.path.endsWith('create') ? 'active' : undefined)}">Create Furniture</a>
        <a id="profileLink" href="/my-furniture" class="${ifDefined(context.path.endsWith('my-furniture') ? 'active' : undefined)}">My Publications</a>
        <a id="logoutBtn" href="/logout">Logout</a>
    </div>` :
    html`
        <div id="guest">
        <a id="loginLink" href="/login" class="${ifDefined(context.path.endsWith('login') ? 'active' : undefined)}">Login</a>
        <a id="registerLink" href="/register" class="${ifDefined(context.path.endsWith('register') ? 'active' : undefined)}">Register</a>
    </div>`}
</nav>`;


function getView(context, next) {
    let result = navPageTemplate(context);

    context.renderNav(result);

    next();
}

export default {
    getView
}