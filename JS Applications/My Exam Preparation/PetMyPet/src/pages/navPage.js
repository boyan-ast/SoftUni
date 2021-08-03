import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (isLoggedIn, logoutClick, userEmail) => html`
${isLoggedIn ? 
    html`
    <section class="navbar-dashboard">
        <div class="first-bar">
            <a href="/dashboard">Dashboard</a>
            <a class="button" href="/my-pets">My Pets</a>
            <a class="button" href="/create">Add Pet</a>
        </div>
        <div class="second-bar">
            <ul>
                <li>Welcome, ${userEmail}!</li>
                <li><a @click="${logoutClick}" href="javascript:void(0)"><i class="fas fa-sign-out-alt"></i> Logout</a></li>
            </ul>
        </div>
    </section>` :
    html`
    <section class="navbar-anonymous">
        <ul>
            <li><a href="/register"><i class="fas fa-user-plus"></i> Register</a></li>
            <li><a href="/login"><i class="fas fa-sign-in-alt"></i> Login</a></li>
        </ul>
    </section>`}`;

function getView(context, next) {
    let isLoggedIn = authService.isLoggedIn();
    let result = navPageTemplate(isLoggedIn, logoutClick, authService.getEmail());

    context.renderNav(result);

    next();

    async function logoutClick(e){
        e.preventDefault();

        await authService.logout(); 
        context.page.redirect('/home');
    }
}

export default {
    getView
}