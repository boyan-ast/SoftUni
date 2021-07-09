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

    //TODO: Validate email

    if (password.trim() === '' || (password !== secondPassword)) {
        console.error('Incorrect Password');
        form.reset();
        return;
    }

    let newUser = {
        email,
        password
    }

    //TODO Try - Catch

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

    //TODO Try - Catch

    let response = await fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });

    let loginResult = await response.json();

    console.log(loginResult);

    let userToken = loginResult.accessToken;
    let userId = loginResult._id;

    localStorage.setItem('token', userToken);
    localStorage.setItem('userId', userId);

    location.assign('./index.html');
}