import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let registerPageTemplate = (form) => html`
<section id="form-sign-up">
    <form @submit="${form.onSubmit} "class="text-center border border-light p-5">
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" placeholder="Email" name="email" value="">
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input type="password" class="form-control" placeholder="Password" name="password" value="">
        </div>

        <div class="form-group">
            <label for="repeatPassword">Repeat Password</label>
            <input type="password" class="form-control" placeholder="Repeat-Password" name="repeatPassword" value="">
        </div>

        <button type="submit" class="btn btn-primary">Register</button>
    </form>
    </section>`;

function getView(context) {
    let form = {
        onSubmit
    }
    let result = registerPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let email = formData.get('email');
        let password = formData.get('password');
        let rePassword = formData.get('repeatPassword');

        if (email == '' || password.length < 6 || (password != rePassword)) {
            alert('Invalid data!');
            return;
        }

        let newUser = {
            email,
            password
        };

        let res = await authService.register(newUser);
        
        context.page.redirect('/home');
    }
}

export default {
    getView
}