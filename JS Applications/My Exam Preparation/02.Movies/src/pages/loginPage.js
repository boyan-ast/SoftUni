import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (form) => html`
<section id="form-login">
<form @submit="${form.onSubmit} "class="text-center border border-light p-5">
    <div class="form-group">
        <label for="email">Email</label>
        <input type="email" class="form-control" placeholder="Email" name="email" value="">
    </div>
    <div class="form-group">
        <label for="password">Password</label>
        <input type="password" class="form-control" placeholder="Password" name="password" value="">
    </div>

    <button type="submit" class="btn btn-primary">Login</button>
</form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }
    let result = loginPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let email = formData.get('email');
        let password = formData.get('password');

        let user = {
            email,
            password
        };

        let res = await authService.login(user);
        
        context.page.redirect('/home');
    }
}

export default {
    getView
}