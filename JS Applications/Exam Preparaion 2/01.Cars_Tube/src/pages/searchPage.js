import { html } from '../../node_modules/lit-html/lit-html.js';

import carsService from '../services/carsService.js';
import { singleCarTemplate } from './shared/singleCarTemplate.js';

let searchPageTemplate = (input) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click="${input.onClick}" class="button-list">Search</button>
    </div>

    ${input.btnClicked ? 
    html`
    <h2>Results:</h2>
    <div class="listings">
        ${input.matchCars.length > 0 ?
        html`${input.matchCars.map(c => singleCarTemplate(c))}` :
        html`<p class="no-cars"> No results.</p>`
        }` : ''}    
    </div>
</section>`;

function getView(context) {
    let input = {
        btnClicked: false,
        onClick,
        matchCars: []
    }
    
    let result = searchPageTemplate(input);

    context.renderView(result);

    async function onClick(e) {
        e.preventDefault();
        input.btnClicked = true;

        let searchText = document.getElementById('search-input').value;
        let resultCars = await carsService.getCarsByYear(Number(searchText));
        
        input.matchCars = resultCars;

        result = searchPageTemplate(input);

        context.renderView(result);
    }
}

export default {
    getView
}