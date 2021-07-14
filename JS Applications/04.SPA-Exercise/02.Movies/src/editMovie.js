import { homePage } from './homePage.js';

let homePageSection = document.getElementById('home-page');
let h1MoviesElement = document.querySelector('h1.text-center');
let movieSection = document.getElementById('movie');
let addMovieSection = document.getElementById('add-movie-button');
let editMovieSection = document.getElementById('edit-movie');
let editMoveForm = editMovieSection.querySelector('form');

export function editMovie(e) {
    e.preventDefault();

    homePageSection.classList.add('hidden');
    h1MoviesElement.classList.add('hidden');
    movieSection.classList.add('hidden');
    editMovieSection.classList.remove('hidden');
    addMovieSection.classList.add('hidden');

    let movieDetailsElement = document.querySelector('section.movie-details');
    if (!movieDetailsElement.classList.contains('hidden')) {
        movieDetailsElement.classList.add('hidden');
    }

    editMovieSection.addEventListener('submit', edit);
}

async function edit(e) {
    e.preventDefault();
    let movieDetailsElement = document.querySelector('section.movie-details');
    let id = movieDetailsElement.dataset.id;

    let formData = new FormData(editMoveForm);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    let editResponse = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify({
            title,
            description,
            img
        })
    });

    console.log(editResponse);

    if (editResponse.status == 200) {
        editMoveForm.reset();
        homePage();
    }
}