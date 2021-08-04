import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (loginForm, registerForm) => html`
<section class="clearfix" id="welcome-section">
    <div class="welcome-text">
        <h1>What is Lorem Ipsum?</h1>
        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
            industry's
            standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled
            it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic
            typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset
            sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus
            PageMaker including versions of Lorem Ipsum.</p>
    </div>
    <div class="welcome-forms">
        <div class="welcome-login-form">
            <h1>Sign in</h1>
            <form @submit="${loginForm.onSubmit}" id="login-form">
                <label for="username-login">Email</label>
                <input type="text" name="email-login" id="email-login" placeholder="Email">
                <label for="password-login">Password</label>
                <input type="password" name="password-login" id="password-login" placeholder="Password">
                <input id="loginBtn" type="submit" value="Login" />
            </form>
        </div>
        <div class="welcome-rigister-form">
            <h1>Register</h1>
            <form @submit="${registerForm.onSubmit}" id="register-form">
                <label for="username-register">Email</label>
                <input type="text" name="email-register" id="email-register" placeholder="Email">
                <label for="password-register">Password</label>
                <input type="password" name="password-register" id="password-register" placeholder="Password">
                <label for="password-register-check">Password check</label>
                <input type="password" name="password-register-check" id="password-register-check"
                    placeholder="Repeat password">
                <input id="registerBtn" type="submit" value="Register" />
            </form>
        </div>
    </div>
</section>`;

function getView(context) {
    let loginForm = {
        onSubmit: loginSubmit
    };

    let registerForm = {
        onSubmit: registerSubmit
    };

    let result = loginPageTemplate(loginForm, registerForm);

    context.renderView(result);

    async function loginSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let email = formData.get('email-login');
        let password = formData.get('password-login');

        if (email.length < 5 || password.length < 3) {
            alert('Invalid data!');
            return;
        }

        let response = await authService.login({
            email,
            password
        });

        context.page.redirect('/overview');
    }

    async function registerSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let email = formData.get('email-register');
        let password = formData.get('password-register');
        let rePassword = formData.get('password-register-check');

        if (email.length < 5 || password.length < 3 || password != rePassword) {
            alert('Invalid data!');
            return;
        }

        let response = await authService.register({
            email,
            password
        });

        context.page.redirect('/overview');
    }
}

export default {
    getView
}