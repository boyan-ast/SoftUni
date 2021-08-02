import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = () => html`
<div class="collapse navbar-collapse" id="navbarText">
${authService.isLoggedIn() ? 
    html`
    <ul class="navbar-nav mr-auto">
        <li class="nav-item active">
            <a class="nav-link" href="/home">Home <span class="sr-only">(current)</span></a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="/all-songs">All Songs</a>
        </li>
        <li class="nav-item">
            <a class="nav-link " href="my-songs">My Songs</a>
        </li>
    </ul>
    <ul class="navbar-nav justify-content-end">
        <li class="nav-item">
            <a class="nav-link" href="/home">Welcome, ${authService.getEmail()}!</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="/logout">Logout</a>
        </li>
    </ul>` :
    html`
    <ul class="navbar-nav mr-auto">
    </ul>
    <ul class="navbar-nav justify-content-end">
        <li class="nav-item">
            <a class="nav-link" href="/login">Login</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="/register">Register</a>
        </li>
    </ul>`}
</div>`;

function getView(context, next) {
    let result = navPageTemplate();

    context.renderNav(result);

    next();
}

export default {
    getView
}