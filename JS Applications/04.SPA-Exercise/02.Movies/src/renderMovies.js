import { createElement } from './createElement.js';

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

        let imgElement = createElement('img', { class: 'card-img-top', src: imgUrl, alt: 'Card image cap', width: '400' });
        let h4Element = createElement('h4', { class: 'card-title' }, title);
        let cardBodyElement = createElement('div', { class: 'card-body' }, h4Element);
        let btnElement = createElement('button', { type: 'button', class: 'btn btn-info' }, 'Details');
        let aElement = createElement('a', { href: '#' }, btnElement);
        let cardFooterElement = createElement('div', { class: 'card-footer hidden' }, aElement);

        btnElement.addEventListener('click', function(e) {
            showMovie(e, title, description, imgUrl, ownerId);
        });

        let divCardElement = createElement('div', { class: 'card mb-4' }, imgElement, cardBodyElement, cardFooterElement);
        divCardElement.dataset.ownerId = ownerId;

        moviesDivElement.appendChild(divCardElement);
    })
}

function showMovie(e, title, description, url) {
    e.preventDefault();

    let divCardElement = e.currentTarget.parentElement.parentElement.parentElement;

    let templateDetailsElement = document.getElementById('movie-example');
    let detailsSectionElement = templateDetailsElement.cloneNode(true);
    detailsSectionElement.classList.remove('hidden');
    detailsSectionElement.classList.add('movie-details')
    detailsSectionElement.querySelector('div>h1').textContent = `Movie title: ${title}`;
    detailsSectionElement.querySelector('div>img.img-thumbnail').src= url;
    detailsSectionElement.querySelector('div>p').textContent = description;

    let deleteButton = detailsSectionElement.querySelector('.btn-danger');
    deleteButton.classList.add('hidden');
    let editButton = detailsSectionElement.querySelector('.btn-warning');
    editButton.classList.add('hidden');
    let likeButton = detailsSectionElement.querySelector('.btn-primary');

    let cardOwnerId = divCardElement.dataset.ownerId;

    if (cardOwnerId == localStorage.getItem('id')) {
        deleteButton.classList.remove('hidden');
        editButton.classList.remove('hidden');
    }


    templateDetailsElement.replaceWith(detailsSectionElement);
}

{/* <section id="movie-example" class="hidden">
<div class="container">
    <div class="row bg-light text-dark">
        <h1>Movie title: Black Widow</h1>

        <div class="col-md-8">
            <img class="img-thumbnail" src="https://miro.medium.com/max/735/1*akkAa2CcbKqHsvqVusF3-w.jpeg"
                alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>Natasha Romanoff aka Black Widow confronts the darker parts of her ledger when a dangerous
                conspiracy
                with ties to her past arises. Comes on the screens 2020.</p>
            <a class="btn btn-danger" href="#">Delete</a>
            <a class="btn btn-warning" href="#">Edit</a>
            <a class="btn btn-primary" href="#">Like</a>
            <span class="enrolled-span">Liked 1</span>
        </div>
    </div>
</div>
</section> */}