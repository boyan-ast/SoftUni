import { html } from '../../node_modules/lit-html/lit-html.js';

import authService from '../services/authService.js';
import carsService from '../services/carsService.js';
import { singleCarTemplate } from './shared/singleCarTemplate.js';

let myListingsPageTemplate = (myCars) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        ${myCars.length > 0 ?
        myCars.map(c => singleCarTemplate(c)) :
        html`
        <p class="no-cars"> You haven't listed any cars yet.</p>`}
    </div>
</section>`;

async function getView(context) {
    try {
        let cars = await carsService.getMyCars(authService.getUserId());

        let result = myListingsPageTemplate(cars);

        context.renderView(result);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}