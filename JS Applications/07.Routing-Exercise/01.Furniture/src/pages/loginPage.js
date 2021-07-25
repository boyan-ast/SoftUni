import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";

let loginTemplate = (form) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Login User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${form.onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <input type="submit" class="btn btn-primary" value="Login" />
        </div>
    </div>
</form>`;

function getView(context) {
    let form = {
        onSubmit
    }

    let result = loginTemplate(form);
    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let password = formData.get('password');

        let response = await authService.login({ email, password });

        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}