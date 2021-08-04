import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";

let navPageTemplate = (context) => html`
${authService.isLoggedIn() ? 
    html`
        <div id="cashier">
            <span>Cashier: </span>
            <a href="/">${authService.getEmail()}</a>
        </div>
        <nav id="nav">
            <ul>
                <li>
                    <a href="/overview">Overview</a>
                </li>
                <li>
                    <a href="/logout" class="logout">Logout</a>
                </li>
            </ul>
        </nav>
        ` : 
    html`
        <nav id="nav">
            <ul>
                <li>
                    <a href="/login">Login</a>
                </li>
            </ul>
        </nav>`
}`;

function getView(context, next) {
    let result = navPageTemplate();

    context.renderNav(result);

    next();
}

export default {
    getView
}