import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import notificationPage from './notificationPage.js';

let loginPageTemplate = (form) => html`
<!-- Login Page ( Only for guest users ) -->
<section id="login">
    <form @submit="${form.onSubmit}" id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
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
        let errorMessages = [];

        let formElement = e.currentTarget;

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');

        if (email == '') {
            errorMessages.push('Email is required!');
        }

        if (password == '') {
            errorMessages.push('Password is required!');
        }

        if (errorMessages.length > 0) {
            notificationPage.getNotification(errorMessages.join('\n'));
            return;
        }

        let user = {
            email,
            password,
        };

        try {
            let response = await authService.login(user);
            context.page.redirect('/all-memes');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}