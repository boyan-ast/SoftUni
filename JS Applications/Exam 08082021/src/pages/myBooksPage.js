import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import booksService from '../services/booksService.js';
import { singleBookTemplate } from './shared/singleBookTemplate.js';

let myBooksPageTemplate = (books) => html`
<!-- My Books Page ( Only for logged-in users ) -->
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    ${books.length > 0 ?
    html`
    <ul class="my-books-list">
        ${books.map(b => singleBookTemplate(b))}
    </ul>` :
    html`
    <p class="no-books">No books in database!</p>`}
</section>`;

async function getView(context) {
    try {
        let myBooks = await booksService.getMyBooks(authService.getUserId());

        let result = myBooksPageTemplate(myBooks);

        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}