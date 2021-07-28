import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import moviesService from '../services/moviesService.js';

let singleMovieTemplate = (movie, isLoggedIn) => html`
<div class="card mb-4">
    <img class="card-img-top" src="${movie.img}" alt="Card image cap"
        width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        ${isLoggedIn ? html`
        <a href="/details/${movie._id}">
            <button type="button" class="btn btn-info">Details</button>
        </a>` : ''}
    </div>

</div>`;

let homePageTemplate = (allMovies, isLoggedIn) => html`
<section id="home-page">
    <div class="jumbotron jumbotron-fluid text-light" style="background-color: #343a40;">
        <img src="https://slicksmovieblog.files.wordpress.com/2014/08/cropped-movie-banner-e1408372575210.jpg"
            class="img-fluid" alt="Responsive image" style="width: 150%; height: 200px">
        <h1 class="display-4">Movies</h1>
        <p class="lead">Unlimited movies, TV shows, and more. Watch anywhere. Cancel anytime.</p>
    </div>
</section>

<h1 class="text-center">Movies</h1>

${isLoggedIn ? html`
<section id="add-movie-button">
    <a href="/add-movie" class="btn btn-warning ">Add Movie</a>
</section>` : ''}

<section id="movie">
    <div class=" mt-3 ">
        <div class="row d-flex d-wrap">
            <div class="card-deck d-flex justify-content-center">
                ${allMovies.map(m => singleMovieTemplate(m, isLoggedIn))}
            </div>
        </div>
    </div>
</section>
`;

async function getView(context) {
    let allMovies = await moviesService.getAll();
    let result = homePageTemplate(allMovies, authService.isLoggedIn());

    context.renderView(result);
}

export default {
    getView
}