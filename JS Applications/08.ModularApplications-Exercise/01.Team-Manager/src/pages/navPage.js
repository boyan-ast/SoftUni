import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let navTemplate = () => html`
<a href="/home" class="site-logo">Team Manager</a>
<nav>
    <a href="/browse" class="action">Browse Teams</a>

    ${
    authService.isLoggedIn() ?
    html`<a href="/my-teams" class="action user">My Teams</a>
    <a href="/logout" class="action user">Logout</a>` :
    html`<a href="/login" class="action guest">Login</a>
    <a href="/register" class="action guest">Register</a>`
    }
</nav>`;

function getView(context, next) {
    let result = navTemplate();

    context.renderNav(result);

    next();
}

export default {
    getView
}