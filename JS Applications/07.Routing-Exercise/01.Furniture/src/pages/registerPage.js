import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";

let registerTemplate = (form) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
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
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;

function getView(context) {
    let form = {
        onSubmit,
    }
    let result = registerTemplate(form);
    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let password = formData.get('password');
        let rePassword = formData.get('rePass');

        if(password !== rePassword) {
            console.error('Passwords don\'t match!');
            return;
        }

        let newUser = {
            email,
            password
        };

        await authService.register(newUser);

        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}