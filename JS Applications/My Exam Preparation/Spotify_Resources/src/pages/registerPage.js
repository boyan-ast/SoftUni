import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import songsService from '../services/songsService.js';

let registerPageTemplate = (form) => html`
<section id="registerView">
    <div class="background-spotify">
        <div class="song-container">
            <h1>Register</h1>
            <form @submit="${form.onSubmit}">
                <div class="form-group">
                    <label for="username" class="white-labels">Email</label>
                    <input type="text" name="email" class="form-control" placeholder="Enter email">
                </div>
                <div class="form-group">
                    <label for="password" class="white-labels">Password</label>
                    <input type="password" name="password" class="form-control" placeholder="Password">
                </div>
                <button type="submit" class="btn btn-primary">Register</button>
            </form>
            <h4 class="mt-3 text-white">Already have an account? <a href="/login" class="add-link">Login</a></h4>
        </div>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }

    let result = registerPageTemplate(form);

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

        let newUser = {
            email,
            password
        };

        let response = await authService.register(newUser);

        context.page.redirect('/home');
    }
}

export default {
    getView
}