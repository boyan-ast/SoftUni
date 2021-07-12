let homePageSection = document.getElementById('home-page');
let h1MoviesElement = document.querySelector('h1.text-center');
let movieSection = document.getElementById('movie');
let loginSection = document.getElementById('form-login');
let navElement = document.querySelector('nav.navbar');
let registerSection = document.getElementById('form-sign-up');
let loginForm = loginSection.querySelector('form.text-center');

export function login() {
    homePageSection.classList.add('hidden');
    h1MoviesElement.classList.add('hidden');
    movieSection.classList.add('hidden');
    loginSection.classList.remove('hidden');

    if (!registerSection.classList.contains('hidden')){
        registerSection.classList.add('hidden');
    }

    loginForm.addEventListener('submit', loginUser);
}

async function loginUser(e) {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    let registerResponse = await fetch('http://localhost:3030/users/login', {
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

        loginSection.classList.add('hidden');
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

        loginForm.reset();
    } else {
        console.error('User not registered! Try again!');
    }

}