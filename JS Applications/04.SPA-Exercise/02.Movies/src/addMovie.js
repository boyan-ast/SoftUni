import { postMovie } from './postMovie.js';

let homePageSection = document.getElementById('home-page');
let h1MoviesElement = document.querySelector('h1.text-center');
let movieSection = document.getElementById('movie');
let addMovieSection = document.getElementById('add-movie');
let addMoveForm = addMovieSection.querySelector('form');

export function addMovie(e) {
    e.preventDefault();
    e.currentTarget.parentElement.classList.add('hidden');

    homePageSection.classList.add('hidden');
    h1MoviesElement.classList.add('hidden');
    movieSection.classList.add('hidden');

    addMovieSection.classList.remove('hidden');

    let movieDetailsElement = document.querySelector('section.movie-details');

    if (!movieDetailsElement.classList.contains('hidden')) {
        movieDetailsElement.classList.add('hidden');
    }

    addMoveForm.addEventListener('submit', postMovie);
}