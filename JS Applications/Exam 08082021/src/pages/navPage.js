import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn, email) => html`
 <!-- Navigation -->
 <nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        ${!isLoggedIn ? 
        html`
        <!-- Guest users -->
        <div id="guest">
            <a class="button" href="/login">Login</a>
            <a class="button" href="/register">Register</a>
        </div>` :
        html`
        <!-- Logged-in users -->
        <div id="user">
            <span>Welcome, ${email}</span>
            <a class="button" href="/my-books">My Books</a>
            <a class="button" href="/create">Add Book</a>
            <a class="button" href="/logout">Logout</a>
        </div>`}
    </section>
</nav>`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();
    let userEmail = authService.getEmail();

    let result = navPageTemplate(isLoggedIn, userEmail);

    context.renderNav(result);

    next();
}

export default {
    getView
}