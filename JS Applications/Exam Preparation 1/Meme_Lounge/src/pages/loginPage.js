import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";

let loginTemplate = (form) => html`        
<section id="login">
    <form @submit=${form.submitHandler} id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="#">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;

function getView(context) {
    let form = {
        submitHandler,
    }

    let result = loginTemplate(form);

    context.renderView(result);

    async function submitHandler(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let password = formData.get('password');

        if (email.trim() == '' || password.trim() == '') {
            window.alert('All fields are required!');
        }

        try {
            let response = await authService.login({ email, password });
            console.log(response);
            //redirect to AllMemes
            context.page.redirect('/allMemes');
        } catch (error) {
            window.alert(error.message);
        }

    }
}

export default {
    getView
}

