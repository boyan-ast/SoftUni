import { html } from "../../node_modules/lit-html/lit-html.js";

import { furnitureTemplate } from '../sharedTemplates/singleFurniture.js';
import furnitureService from "../services/furnitureService.js";

let dashboardTemplate = (allFurniture) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
    ${allFurniture.map(f => furnitureTemplate(f))}
</div>`;

async function getView(context) {
    let allFurniture = await furnitureService.getAll();
    let result = dashboardTemplate(allFurniture);
    context.renderView(result);
}

export default {
    getView
}



