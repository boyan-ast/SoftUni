import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (form) => html`
<div class="container home wrapper  my-md-5 pl-md-5">
    <div class="row-form d-md-flex flex-mb-equal ">
        <div class="col-md-4">
            <img class="responsive" src="./images/idea.png" alt="">
        </div>
        <form @submit="${form.onSubmit} "class="form-user col-md-7">
            <div class="text-center mb-4">
                <h1 class="h3 mb-3 font-weight-normal">Login</h1>
            </div>
            <div class="form-label-group">
                <label for="inputEmail">Email</label>
                <input type="text" id="inputEmail" name="email" class="form-control" placeholder="Email" required=""
                    autofocus="">
            </div>
            <div class="form-label-group">
                <label for="inputPassword">Password</label>
                <input type="password" id="inputPassword" name="password" class="form-control"
                    placeholder="Password" required="">
            </div>
            <div class="text-center mb-4 text-center">
                <button class="btn btn-lg btn-dark btn-block" type="submit">Sign In</button>
                <p class="alreadyUser"> Don't have account? Then just
                    <a href="">Sign-Up</a>!
                </p>
            </div>
            <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2019.</p>
        </form>
    </div>
</div>`;

function getView(context) {
    let form = {
        onSubmit
    };

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

        try {
            let response = await authService.login(user);
            formElement.reset();
            context.page.redirect('/home');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}