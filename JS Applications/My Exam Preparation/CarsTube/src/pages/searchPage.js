import { html } from '../../node_modules/lit-html/lit-html.js';
import carsService from '../services/carsService.js';

import { singleCarTemplate } from './shared/singleCarTemplate.js';

let searchPageTemplate = (cars, onSearch) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click="${onSearch}" class="button-list">Search</button>
    </div>
    <h2>Results:</h2>
    <div class="listings">
        ${cars.length > 0 ?
        cars.map(c => singleCarTemplate(c)) :
        html`
        <p class="no-cars"> No results.</p>`}
    </div>
</section>`;

function getView(context) {
    let cars = [];

    let result = searchPageTemplate(cars, onSearch);

    context.renderView(result);

    async function onSearch(e) {
        let btnElement = e.currentTarget;

        let inputElement = btnElement.parentElement.children[0];

        let searchValue = inputElement.value;

        try {
            let cars = await carsService.getCarsByYear(searchValue);

            result = searchPageTemplate(cars, onSearch);
            inputElement.value = '';

            context.renderView(result);
        } catch (e) {
            alert(e.message);
        }
    }
}

export default {
    getView
}