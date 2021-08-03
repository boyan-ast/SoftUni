import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let registerPageTemplate = (form) => html`
<section class="register">
    <form @submit="${form.onSubmit}">
        <fieldset>
            <legend>Register</legend>
            <p class="field">
                <label for="username">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email" />
                    <span class="actions"></span>
                    <i class="fas fa-user"></i>
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password" />
                    <span class="actions"></span>
                    <i class="fas fa-key"></i>
                </span>
            </p>
            <input class="button" type="submit" class="submit" value="Register" />
        </fieldset>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = registerPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();
        let invalidData = [];

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');

        if (email.length < 3) {
            invalidData.push('Email must be at least 3 symbols');
        }

        if (password.length < 6) {
            invalidData.push('Password must be at least 6 symbols');
        }

        if (invalidData.length > 0) {
            alert(invalidData.join('\n'));
            return;
        }

        let newUser = {
            email,
            password
        }

        let response = await authService.register(newUser);

        context.page.redirect('/home');
    }
}

export default {
    getView
}