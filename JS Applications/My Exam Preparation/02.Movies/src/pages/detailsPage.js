import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import moviesService from '../services/moviesService.js';

let detailsPageTemplate = (movie, onDeleteClick, onLikeClick) => html`
    <section id="movie-example">
        <div class="container">
            <div class="row bg-light text-dark">
                <h1>Movie title: ${movie.title}</h1>
    
                <div class="col-md-8">
                    <img class="img-thumbnail" src="${movie.img}"
                        alt="${movie.title}">
                </div>
                <div class="col-md-4 text-center">
                    <h3 class="my-3 ">Movie Description</h3>
                    <p>${movie.description}</p>

                    ${authService.currentUserIsOwner(movie._ownerId) ? 
                    html`
                    <a @click=${onDeleteClick} class="btn btn-danger" href="javascript:void(0)">Delete</a>
                    <a class="btn btn-warning" href="/edit/${movie._id}">Edit</a>` :
                    html`
                    ${!movie.userLikedMovie ? html`<a @click=${onLikeClick} class="btn btn-primary" href="javascript:void(0)">Like</a>` : ''}`}    
                    <span class="enrolled-span">Liked ${movie.likesCount}</span>
                </div>
            </div>
        </div>
    </section>`;

async function getView(context) {
    let movieId = context.params.id;
    let movie = await moviesService.getOne(movieId);
    let likesCount = await moviesService.getNumberOfLikes(movieId);
    movie.likesCount = likesCount;
    let userLikesForTheMovie = await moviesService.getUserLikesForMovie(movieId, authService.getUserId());
    let userLikedMovie = userLikesForTheMovie.length == 1;
    movie.userLikedMovie = userLikedMovie;

    let result = detailsPageTemplate(movie, onDeleteClick, onLikeClick);

    context.renderView(result);

    async function onDeleteClick(e) {
        e.preventDefault();

        let res = await moviesService.deleteOne(movieId);
        context.page.redirect('/home');
    }

    async function onLikeClick(e) {
        e.preventDefault();
        let response = await moviesService.addLike({movieId});
        return context.page.redirect(`/details/${movieId}`);
    }    
}

export default {
    getView
}