import { html } from '../../node_modules/lit-html/lit-html.js';

import authService from '../services/authService.js';
import furnitureService from '../services/furnitureService.js';
import { singleFurnitureTemplate } from './shared/singleFurnitureTemplate.js';

let myFurniturePageTemplate = (myFurniture) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>My Furniture</h1>
        <p>This is a list of your publications.</p>
    </div>
</div>
<div class="row space-top">
    ${myFurniture.map(f => singleFurnitureTemplate(f))}
</div>`;

async function getView(context) {
    let myFurniture;

    try {
        myFurniture = await furnitureService.getMyFurniture(authService.getUserId());
        let result = myFurniturePageTemplate(myFurniture);

        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}