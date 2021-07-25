import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";

let registerTemplate = (form) => html`
        <section id="register">
            <form @submit=${form.onSubmit} id="register-form">
                <div class="container">
                    <h1>Register</h1>
                    <label for="username">Username</label>
                    <input id="username" type="text" placeholder="Enter Username" name="username">
                    <label for="email">Email</label>
                    <input id="email" type="text" placeholder="Enter Email" name="email">
                    <label for="password">Password</label>
                    <input id="password" type="password" placeholder="Enter Password" name="password">
                    <label for="repeatPass">Repeat Password</label>
                    <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
                    <div class="gender">
                        <input type="radio" name="gender" id="female" value="female">
                        <label for="female">Female</label>
                        <input type="radio" name="gender" id="male" value="male" checked>
                        <label for="male">Male</label>
                    </div>
                    <input type="submit" class="registerbtn button" value="Register">
                    <div class="container signin">
                        <p>Already have an account?<a href="#">Sign in</a>.</p>
                    </div>
                </div>
            </form>
        </section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = registerTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let username = formData.get('username');
        let email = formData.get('email');
        let password = formData.get('password');
        let rePassword = formData.get('repeatPass');
        let femaleGenderElement = formElement.querySelector('#female');
        let gender = femaleGenderElement.checked ? 'female' : 'male';

        if(username == '' || email == '' || password == '' || rePassword == '' || (password !== rePassword)) {
            window.alert('All fields should be filled and the passwords must match!');
            return;
        }

        let newUser = {
            username,
            email,
            password,
            gender
        }

        try {
            let response = await authService.register(newUser);
            context.page.redirect('/allMemes')
        } catch (error) {
            window.alert(error.message);
        }
        

    }
}

export default {
    getView
}