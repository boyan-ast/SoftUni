import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';

import authService from '../services/authService.js';

let loginTemplate = (form) => html`
            <section id="login">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>Login</h1>
                    </header>
                    <form @submit="${form.onSubmit} "id="login-form" class="main-form pad-large">
                        <div class="error ${ifDefined(form.isInvalid ? undefined : " hidden")}">Error message.</div>
                        <label>E-mail: <input type="text" name="email"></label>
                        <label>Password: <input type="password" name="password"></label>
                        <input class="action cta" type="submit" value="Sign In">
                    </form>
                    <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
                    </footer>
                </article>
            </section>`;

function getView(context) {
    let form = {
        onSubmit,
        isInvalid: false,
    }

    let result = loginTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let password = formData.get('password');

        let response = await authService.login({
            email,
            password,
        });

        if (email == '' || password.length < 3) {
            form.isInvalid = true;

            let result = loginTemplate(form);

            return context.renderView(result);
        }

        console.log(response);

        //context.page.redirect('/my-teams');
    }
}

export default {
    getView
}