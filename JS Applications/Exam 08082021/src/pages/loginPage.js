import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (form) => html`
<!-- Login Page ( Only for Guest users ) -->
<section id="login-page" class="login">
    <form @submit="${form.onSubmit}" id="login-form" action="" method="">
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
        </fieldset>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = loginPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');

        if (email == '' || password == '') {
            alert('Invalid data!');
            return;
        }

        let user = {
            email,
            password
        };

        try {
            let response = await authService.login(user);
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}