import { html } from '../../node_modules/lit-html/lit-html.js';

import booksService from '../services/booksService.js';
import { singleBookTemplate } from './shared/singleBookTemplate.js';

let dashboardPageTemplate = (allBooks) => html`
<!-- Dashboard Page ( for Guests and Users ) -->
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    ${allBooks.length > 0 ?
    html`
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="other-books-list">
        ${allBooks.map(b => singleBookTemplate(b))}
    </ul>` :
    html`
    <!-- Display paragraph: If there are no books in the database -->
    <p class="no-books">No books in database!</p>`}
</section>`;

async function getView(context) {
    try {
        let allBooks = await booksService.getAllBooks();

        let result = dashboardPageTemplate(allBooks);

        context.renderView(result);
    } catch (e) {
        alert(e.message);
    }
}

export default {
    getView
}