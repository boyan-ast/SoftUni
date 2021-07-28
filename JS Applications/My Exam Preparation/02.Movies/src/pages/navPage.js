import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn) => html`
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <a class="navbar-brand text-light" href="/home">Movies</a>
    <ul class="navbar-nav ml-auto ">
    ${isLoggedIn ? 
    html`
    <li class="nav-item">
            <a class="nav-link">Welcome, ${authService.getEmail()}</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="/logout">Logout</a>
        </li>` :
    html`            
    <li class="nav-item">
            <a class="nav-link" href="/login">Login</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="/register">Register</a>
    </li>
    `}

    </ul>
</nav>`;

function getView(context, next) {
    let result = navPageTemplate(authService.isLoggedIn());

    context.renderNav(result);

    next();
}

export default {
    getView
}