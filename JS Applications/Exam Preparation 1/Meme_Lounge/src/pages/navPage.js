import { html } from "../../node_modules/lit-html/lit-html.js";
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js';

import authService from "../services/authService.js";

let navTemplate = () => html`
${authService.isLoggedIn() ? 
    html`
        <a href="/allMemes">All Memes</a>
        <div class="user">
            <a href="/create">Create Meme</a>
            <div class="profile">
                <span>Welcome, ${authService.getEmail()}</span>
                <a href="/profile">My Profile</a>
                <a href="/logout">Logout</a>
            </div>
        </div>` :
    html`
        <div class="guest">
            <div class="profile">
                <a href="/login">Login</a>
                <a href="/register">Register</a>
            </div>
            <a class="active" href="/home">Home Page</a>
            <a href="/allMemes">All Memes</a>
        </div>`
}`;

function getView(context, next) {

    let result = navTemplate();

    context.renderNav(result);

    next();
}

export default {
    getView
}