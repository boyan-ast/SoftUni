import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import booksService from '../services/booksService.js';

let detailsPageTemplate = (book, user, onDeleteClick, likes) => html`
<!-- Details Page ( for Guests and Users ) -->
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <div class="actions">
            ${user.isOwner ? 
            html`
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            <a class="button" href="/edit/${book._id}">Edit</a>
            <a @click="${onDeleteClick}" class="button" href="javascript:void(0)">Delete</a>` :
            html`${(user.isLoggedIn && !likes.userAlreadyLiked) ?
                html`
                <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
                <a @click="${likes.onLikeClick}" class="button" href="javascript:void(0)">Like</a>` : ''}            
            `}
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likes.count}</span>
            </div>
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;
    let book = undefined;

    try {
        book = await booksService.getBook(id);
    } catch (error) {
        alert(error.message);
        return;
    }

    let isOwner = authService.currentUserIsOwner(book._ownerId);
    
    let isLoggedIn = authService.isLoggedIn();

    let user = {
        isOwner,
        isLoggedIn
    };

    let likes = {
        count: await booksService.getBookLikes(id),
        userAlreadyLiked: await booksService.currentUserLikedBook(id),
        onLikeClick
    }

    let result = detailsPageTemplate(book, user, onDeleteClick, likes);

    context.renderView(result);

    async function onDeleteClick(e){
        e.preventDefault();

        try {
            let confirmed = confirm('Are you sure?');

            if(confirmed) {
                await booksService.deleteBook(id);
                context.page.redirect('/dashboard');
            }
        } catch (error) {
            alert(error.message);
        }
    }

    async function onLikeClick(e){
        e.preventDefault();
        try {
            let response = await booksService.likeBook({bookId: id});

            context.page.redirect(`/details/${id}`);
        } catch (e) {
            alert(e.message);
        }
    }
}

export default {
    getView
}