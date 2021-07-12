let homePageSection = document.getElementById('home-page');
let h1MoviesElement = document.querySelector('h1.text-center');
let movieSection = document.getElementById('movie');
let registerSection = document.getElementById('form-sign-up');
let loginSection = document.getElementById('form-login');
let navElement = document.querySelector('nav.navbar');
let registerForm = registerSection.querySelector('form.text-center');

export function register() {
    homePageSection.classList.add('hidden');
    h1MoviesElement.classList.add('hidden');
    movieSection.classList.add('hidden');
    registerSection.classList.remove('hidden');

    if (!loginSection.classList.contains('hidden')){
        loginSection.classList.add('hidden');
    }

    registerForm.addEventListener('submit', registerUser);
}

async function registerUser(e) {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePassword = formData.get('repeatPassword');

    if (email == '' || password.length < 6 || (password !== rePassword)) {
        console.error('Invalid input! Try again');
        return;
    }

    let registerResponse = await fetch('http://localhost:3030/users/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    });

    if (registerResponse.status == 200) {
        let registerData = await registerResponse.json();

        let userId = registerData._id;
        let accessToken = registerData.accessToken;
    
        localStorage.setItem('token', accessToken);
        localStorage.setItem('id', userId);

        registerSection.classList.add('hidden');
        homePageSection.classList.remove('hidden');
        h1MoviesElement.classList.remove('hidden');
        movieSection.classList.remove('hidden');
        document.getElementById('add-movie-button').classList.remove('hidden');
        [...document.querySelectorAll('div.card-footer')].forEach(el => el.classList.remove('hidden'));
        let welcomeAElement = navElement.querySelector('ul li:nth-child(1) a');
        welcomeAElement.textContent = `Welcome, ${email}`;
        welcomeAElement.parentElement.classList.remove('hidden');

        let logoutAElement = navElement.querySelector('ul li:nth-child(2) a');
        logoutAElement.parentElement.classList.remove('hidden');

        navElement.querySelector('ul li:nth-child(3)').classList.add('hidden');
        navElement.querySelector('ul li:nth-child(4)').classList.add('hidden');

        registerForm.reset();
    }

}