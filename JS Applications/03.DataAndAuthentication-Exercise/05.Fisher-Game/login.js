let registerForm = document.getElementById('register-form');
let loginForm = document.getElementById('login-form');
let loginElement = document.querySelector('#guest a');

registerForm.addEventListener('submit', registerUser);
loginForm.addEventListener('submit', loginUser);

async function registerUser(e) {
    e.preventDefault();
    let form = e.currentTarget;

    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');
    let secondPassword = formData.get('rePass');

    if (!validateEmail(email)) {
        console.error('Invalid Email');
        return;
    }

    if (password.trim() === '' || (password !== secondPassword)) {
        console.error('Incorrect Password');
        form.reset();
        return;
    }

    let newUser = {
        email,
        password
    }

    try {
        let response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        let registerResult = await response.json();

        console.log(registerResult);

        let userToken = registerResult.accessToken;
        let userId = registerResult._id;

        localStorage.setItem('token', userToken);
        localStorage.setItem('userId', userId);

        location.assign('./index.html');
    } catch (error) {
        console.error('Registration failed!');
    }
}

async function loginUser(e) {
    e.preventDefault();
    let form = e.currentTarget;

    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');

    let user = {
        email,
        password
    }

    try {
        let response = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        if (response.status !== 200) {
            throw new Error();
        }

        let loginResult = await response.json();

        let userToken = loginResult.accessToken;
        let userId = loginResult._id;

        localStorage.setItem('token', userToken);
        localStorage.setItem('userId', userId);

        location.assign('./index.html');
    } catch (error) {
        console.error('Login failed! Try again!');
    }
}

function validateEmail(email) {
    const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(String(email).toLowerCase());
}