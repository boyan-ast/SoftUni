import { html } from "../../node_modules/lit-html/lit-html.js";
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js';

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn, context) => html`
<div class="container">
    <a class="navbar-brand" href="/">
        <img src="./images/idea.png" alt="">
    </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive"
        aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item ${context.pathname.startsWith('/dashboard') ? 'active' : ''}">
                <a class="nav-link" href="/dashboard">Dashboard</a>
            </li>
            ${isLoggedIn ? 
            html`
             <li class="nav-item ${context.pathname.startsWith('/create') ? 'active' : ''}">
                <a class="nav-link" href="/create">Create</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/logout">Logout</a>
            </li>` :
            html`
            <li class="nav-item ${context.pathname.startsWith('/login') ? 'active' : ''}">
                <a class="nav-link " href="/login">Login</a>
            </li>
            <li class="nav-item ${context.pathname.startsWith('/register') ? 'active' : ''}">
                <a class="nav-link" href="/register">Register</a>
            </li>`}           
        </ul>
    </div>
</div>`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();
    let result = navPageTemplate(isLoggedIn, context);

    context.renderNav(result);

    next();
}

export default {
    getView
}