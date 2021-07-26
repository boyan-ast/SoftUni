import { html } from '../../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js';

import authService from '../services/authService.js';

let registerTemplate = (form) => html`
            <section id="register">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>Register</h1>
                    </header>
                    <form @submit=${form.onSubmit} id="register-form" class="main-form pad-large">
                        <div class="error ${ifDefined(form.isInvalid ? undefined : "hidden")}">Error message.</div>
                        <label>E-mail: <input type="text" name="email"></label>
                        <label>Username: <input type="text" name="username"></label>
                        <label>Password: <input type="password" name="password"></label>
                        <label>Repeat: <input type="password" name="repass"></label>
                        <input class="action cta" type="submit" value="Create Account">
                    </form>
                    <footer class="pad-small">Already have an account? <a href="#" class="invert">Sign in here</a>
                    </footer>
                </article>
            </section>`;

function getView(context) {
    let form = {
        onSubmit,
        isInvalid: false,
    }

    let result = registerTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let username = formData.get('username');
        let password = formData.get('password');
        let rePassword = formData.get('repass');

        if (email == '' || username.length < 3 || password.length < 3 || (password !== rePassword)) {
            form.isInvalid = true;

            let result = registerTemplate(form);

            return context.renderView(result);
        }

        let response = await authService.register({
            email,
            password,
            username
        });

        console.log(response);

        context.page.redirect('/my-teams');
    }
}

export default {
    getView
}