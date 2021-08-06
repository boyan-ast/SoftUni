import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn) => html`
<nav>
    <a class="active" href="/home">Home</a>
    <a href="/all-listings">All Listings</a>
    <a href="/search">By Year</a>
${!isLoggedIn ? 
    html`
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>` :
    html`
    <div id="profile">
        <a>Welcome ${authService.getUsername()}</a>
        <a href="/my-listings">My Listings</a>
        <a href="/create">Create Listing</a>
        <a href="/logout">Logout</a>
    </div>`
}    
</nav>`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();

    let result = navPageTemplate(isLoggedIn);

    context.renderNav(result);

    next();
}

export default {
    getView
}