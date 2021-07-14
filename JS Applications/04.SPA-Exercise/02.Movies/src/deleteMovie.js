import { homePage } from './homePage.js';

export async function deleteMovie(e) {
    e.preventDefault();
    let movieDetailsElement = e.currentTarget.closest('.movie-details');

    let id = movieDetailsElement.dataset.id;

    let deleteResponse = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('token')
        }
    });

    homePage();
}