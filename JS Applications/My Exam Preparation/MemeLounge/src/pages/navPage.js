import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn, email) => html`
<a href="/all-memes">All Memes</a>
${isLoggedIn ? 
    html`
    <!-- Logged users -->
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${email}</span>
            <a href="/my-profile">My Profile</a>
            <a href="/logout">Logout</a>
        </div>
    </div>` :
    html`
    <!-- Guest users -->
    <div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/home">Home Page</a>
    </div>`}`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();
    let email = authService.getEmail();
    let result = navPageTemplate(isLoggedIn, email);

    context.renderNav(result);

    next();
}

export default {
    getView
}