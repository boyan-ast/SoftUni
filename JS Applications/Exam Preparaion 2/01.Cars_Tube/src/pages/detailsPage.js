import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

import carsService from '../services/carsService.js';

let detailsPageTemplate = (car, onDeleteClick, userIsOwner) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">${car.description}</p>

        ${userIsOwner ?
        html`
        <div class="listings-buttons">
            <a href="/edit/${car._id}" class="button-list">Edit</a>
            <a @click="${onDeleteClick} " href="javascript:void(0)" class="button-list">Delete</a>
        </div>` : ''}

    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;
    let car = await carsService.getOne(id);

    let result = detailsPageTemplate(car, onDeleteClick, authService.currentUserIsOwner(car._ownerId));

    context.renderView(result);

    async function onDeleteClick(e) {
        e.preventDefault();

        await carsService.deleteOne(id);
        context.page.redirect('/all-listings');
    }
}

export default {
    getView
}