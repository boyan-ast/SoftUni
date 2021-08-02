import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (form) => html`
<section id="loginView">
    <div class="background-spotify">
        <div class="song-container">
            <h1>Login</h1>
            <form @submit="${form.onSubmit}">
                <div class="form-group">
                    <label for="username" class="white-labels">Email</label>
                    <input id="username" type="text" name="email" class="form-control" placeholder="Enter email">
                </div>
                <div class="form-group">
                    <label for="password" class="white-labels">Password</label>
                    <input id="password" type="password" name="password" class="form-control" placeholder="Password">
                </div>
                <button type="submit" class="btn btn-primary">Login</button>
            </form>

            <h4 class="mt-3 text-white">No account yet? <a href="/register" class="add-link">Register</a></h4>
        </div>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }

    let result = loginPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let email = formData.get('email');
        let password = formData.get('password');

        if (email.length < 3 || password.length < 6) {
            alert('Ivalid username or passowrd! Try again!');
            return;
        }

        let user = {
            email,
            password
        };

        let response = await authService.login(user);

        context.page.redirect('/home');
    }
}

export default {
    getView
}