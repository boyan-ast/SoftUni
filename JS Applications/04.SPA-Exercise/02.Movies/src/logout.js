import { login } from './login.js';

let navElement = document.querySelector('nav.navbar');

export async function logout() {
    let movieDetailsElement = document.querySelector('section.movie-details');

    if (!movieDetailsElement.classList.contains('hidden')) {
        movieDetailsElement.classList.add('hidden');
    }

    let addMovieSection = document.getElementById('add-movie');

    if (!addMovieSection.classList.contains('hidden')) {
        addMovieSection.classList.add('hidden');
    }

    let welcomeAElement = navElement.querySelector('ul li:nth-child(1) a');
    welcomeAElement.textContent = '';
    welcomeAElement.parentElement.classList.add('hidden');

    let logoutAElement = navElement.querySelector('ul li:nth-child(2) a');
    logoutAElement.parentElement.classList.add('hidden');

    navElement.querySelector('ul li:nth-child(3)').classList.remove('hidden');
    navElement.querySelector('ul li:nth-child(4)').classList.remove('hidden');
    document.getElementById('add-movie-button').classList.add('hidden');
    [...document.querySelectorAll('div.card-footer')].forEach(el => el.classList.add('hidden'));

    let logoutResponse = await fetch('http://localhost:3030/users/register', {
        method: 'GET',
        headers: {
            'X-Authorization': localStorage.getItem('token')
        }
    });

    if (logoutResponse.status == 200) {
        localStorage.clear();
        login();
    }
}