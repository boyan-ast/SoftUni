import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memesService from '../services/memesService.js';
import notificationPage from './notificationPage.js';

let registerPageTemplate = (form) => html`
<!-- Register Page ( Only for guest users ) -->
<section id="register">
    <form @submit="${form.onSubmit}" id="register-form">
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
                <input type="radio" name="gender" id="male" value="male">
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = registerPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();
        let errorMessages = [];

        let formElement = e.currentTarget;

        let formData = new FormData(e.currentTarget);

        let username = formData.get('username');
        let email = formData.get('email');
        let password = formData.get('password');
        let rePassword = formData.get('repeatPass');

        let gender = formElement.querySelector('#female').checked ? 'female' : 'male';

        if (username == '') {
            errorMessages.push('Username is required!');
        }

        if (email == '') {
            errorMessages.push('Email is required!');
        }

        if (password == '') {
            errorMessages.push('Password is required!');
        }

        if (rePassword == '') {
            errorMessages.push('Repeat password is required!');
        }

        if (password != rePassword) {
            errorMessages.push('The repeated password must be the same!');
        }

        if (errorMessages.length > 0) {
            notificationPage.getNotification(errorMessages.join('\n'));
            return;
        }

        let newUser = {
            username,
            email,
            password,
            gender
        };

        try {
            let response = await authService.register(newUser);
            context.page.redirect('all-memes');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}