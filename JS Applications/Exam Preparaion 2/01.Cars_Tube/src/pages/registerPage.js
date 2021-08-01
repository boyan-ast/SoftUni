import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

let registerPageTemplate = (form) => html`
<section id="register">
    <div class="container">
        <form @submit="${form.onSubmit} "id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = registerPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let username = formData.get('username');
        let password = formData.get('password');
        let rePassword = formData.get('repeatPass');

        if(username == '' || password == '' || password !== rePassword) {
            alert('Invalid input!');
            return;
        }

        let newUser = {
            username,
            password
        };

        try {
            let response = await authService.register(newUser);
            context.page.redirect('/all-listings');          
        } catch (error) {
            alert(error.message);
        }        
    }
}

export default {
    getView
}