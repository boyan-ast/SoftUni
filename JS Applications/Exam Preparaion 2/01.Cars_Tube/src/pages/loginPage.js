import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let loginPageTemplate = (form) => html`
<section id="login">
    <div class="container">
        <form @submit="${form.onSubmit}" id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = loginPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let username = formData.get('username');
        let password = formData.get('password');

        if(username == '' || password == '') {
            alert('Invalid input!');
            return;
        }

        let user = {
            username,
            password
        };

        try {
            let response = await authService.login(user);
            context.page.redirect('/all-listings');          
        } catch (error) {
            alert(error.message);
        }        
    }
}

export default {
    getView
}