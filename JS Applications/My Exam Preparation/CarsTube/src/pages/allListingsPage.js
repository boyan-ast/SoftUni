import { html } from '../../node_modules/lit-html/lit-html.js';

import carsService from '../services/carsService.js';
import { singleCarTemplate } from './shared/singleCarTemplate.js';

let allListingsPageTemplate = (allCars) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
        ${allCars.length > 0 ?
        allCars.map(c => singleCarTemplate(c)) :
        html`
        <p class="no-cars">No cars in database.</p>`}
    </div>
</section>`;

async function getView(context) {
    try {
        let cars = await carsService.getAll();

        let result = allListingsPageTemplate(cars);

        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}