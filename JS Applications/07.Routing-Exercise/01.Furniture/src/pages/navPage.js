import { html } from '../../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js';

import authService from '../services/authService.js';

let navTemplate = (context) => html`
<h1><a href="/">Furniture Store</a></h1>
<nav>
    <a id="catalogLink" href="/dashboard" class="${ifDefined(context.pathname.startsWith('/dashboard') ? 'active' : undefined)}">Dashboard</a>
    ${authService.isLoggedIn() ? html`
    <div id="user">
        <a id="createLink" href="/create" class="${ifDefined(context.pathname.startsWith('/create') ? 'active' : undefined)}">Create Furniture</a>
        <a id="profileLink" href="/my-furniture" class="${ifDefined(context.pathname.startsWith('/my-furniture') ? 'active' : undefined)}">My Publications</a>
        <a id="logoutBtn" href="/logout">Logout</a>
    </div>` : html`    
    <div id="guest">
        <a id="loginLink" href="/login" class="${ifDefined(context.pathname.startsWith('/login') ? 'active' : undefined)}">Login</a>
        <a id="registerLink" href="/register" class="${ifDefined(context.pathname.startsWith('/register') ? 'active' : undefined)}">Register</a>
     </div>`  
    }
</nav>`;

function getView(context, next) {
    let result = navTemplate(context);
    context.renderNav(result);
    next();
}

export default {
    getView
}

