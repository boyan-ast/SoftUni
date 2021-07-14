import { createElement } from './createElement.js';
import { deleteMovie } from './deleteMovie.js';
import { editMovie } from './editMovie.js';
import { likeMovie } from './likeMovie.js';

let moviesDivElement = document.getElementById('movies-cards');

export async function renderMovies() {
    moviesDivElement.innerHTML = '';

    let response = await fetch('http://localhost:3030/data/movies');
    let moviesData = await response.json();

    moviesData.forEach(m => {
        let title = m.title;
        let imgUrl = m.img;
        let ownerId = m._ownerId;
        let description = m.description;
        let id = m._id;

        let imgElement = createElement('img', { class: 'card-img-top', src: imgUrl, alt: 'Card image cap', width: '400' });
        let h4Element = createElement('h4', { class: 'card-title' }, title);
        let cardBodyElement = createElement('div', { class: 'card-body' }, h4Element);
        let btnElement = createElement('button', { type: 'button', class: 'btn btn-info' }, 'Details');
        let aElement = createElement('a', { href: '#' }, btnElement);
        let cardFooterElement = createElement('div', { class: 'card-footer hidden' }, aElement);

        btnElement.addEventListener('click', function (e) {
            showMovie(e, title, description, imgUrl, id);
        });

        let divCardElement = createElement('div', { class: 'card mb-4' }, imgElement, cardBodyElement, cardFooterElement);
        divCardElement.dataset.ownerId = ownerId;

        moviesDivElement.appendChild(divCardElement);

        if (localStorage.getItem('token')) {
            document.getElementById('movie').classList.remove('hidden');
            document.getElementById('add-movie-button').classList.remove('hidden');
            [...document.querySelectorAll('div.card-footer')].forEach(el => el.classList.remove('hidden'));
        }
    })
}

async function showMovie(e, title, description, url, id) {
    e.preventDefault();

    let divCardElement = e.currentTarget.parentElement.parentElement.parentElement;

    let templateDetailsElement = document.getElementById('movie-example');
    let detailsSectionElement = templateDetailsElement.cloneNode(true);
    detailsSectionElement.classList.remove('hidden');
    detailsSectionElement.classList.add('movie-details')
    detailsSectionElement.querySelector('div>h1').textContent = `Movie title: ${title}`;
    detailsSectionElement.querySelector('div>img.img-thumbnail').src = url;
    detailsSectionElement.querySelector('div>p').textContent = description;
    detailsSectionElement.dataset.id = id;

    let deleteButton = detailsSectionElement.querySelector('.btn-danger');
    deleteButton.classList.add('hidden');

    deleteButton.addEventListener('click', deleteMovie);

    let editButton = detailsSectionElement.querySelector('.btn-warning');
    editButton.classList.add('hidden');

    editButton.addEventListener('click', editMovie);

    let likeButton = detailsSectionElement.querySelector('.btn-primary');

    likeButton.addEventListener('click', likeMovie);

    let numberOfLikesResponse = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    let likesSpanElement = detailsSectionElement.querySelector('span.enrolled-span');
    let likes = await numberOfLikesResponse.json();
    likesSpanElement.textContent = `Liked ${likes}`;

    let cardOwnerId = divCardElement.dataset.ownerId;

    if (cardOwnerId == localStorage.getItem('id')) {
        deleteButton.classList.remove('hidden');
        editButton.classList.remove('hidden');
        likeButton.classList.add('hidden');
    } else {
        deleteButton.classList.add('hidden');
        editButton.classList.add('hidden');
        likeButton.classList.remove('hidden');
    }

    templateDetailsElement.replaceWith(detailsSectionElement);
}