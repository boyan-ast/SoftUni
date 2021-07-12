import { homePage } from './homePage.js';
import { login } from './login.js';
import { register } from './register.js';
import { logout } from './logout.js';
import { renderMovies} from './renderMovies.js';

let navElement = document.querySelector('nav.navbar');

navElement.addEventListener('click', loadSection);

let navActions = {
    movies: homePage,
    login: login,
    register: register,
    logout: logout
}

function loadSection(e) {
    e.preventDefault();
    if (e.target.tagName == 'A' && e.target.href) {

        let action = e.target.textContent.toLowerCase();

        navActions[action]();
    }
}

renderMovies();
