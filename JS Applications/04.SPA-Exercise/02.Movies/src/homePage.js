import { renderMovies } from './renderMovies.js';

export function homePage() {
    let homePageSection = document.getElementById('home-page');
    let h1MoviesElement = document.querySelector('h1.text-center');
    let movieSection = document.getElementById('movie');
    let registerSection = document.getElementById('form-sign-up');
    let loginSection = document.getElementById('form-login');
    let editMovieSection = document.getElementById('edit-movie');

    homePageSection.classList.remove('hidden');
    h1MoviesElement.classList.remove('hidden');
    movieSection.classList.remove('hidden');

    renderMovies();

    if (!editMovieSection.classList.contains('hidden')) {
        editMovieSection.classList.add('hidden');
    }
    
    if (!loginSection.classList.contains('hidden')) {
        loginSection.classList.add('hidden');
    }

    if (!registerSection.classList.contains('hidden')) {
        registerSection.classList.add('hidden');
    }

    let movieDetailsElement = document.querySelector('section.movie-details');

    if (!movieDetailsElement.classList.contains('hidden')) {
        movieDetailsElement.classList.add('hidden');
    }

    let addMovieSection = document.getElementById('add-movie');

    if (!addMovieSection.classList.contains('hidden')) {
        addMovieSection.classList.add('hidden');
    }
}