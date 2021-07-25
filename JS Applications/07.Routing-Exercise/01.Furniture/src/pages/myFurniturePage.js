import { html } from "../../node_modules/lit-html/lit-html.js";

import authService from "../services/authService.js";
import furnitureService from "../services/furnitureService.js";
import { furnitureTemplate } from '../sharedTemplates/singleFurniture.js';

let myFurnitureTemplate = (allFurniture) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>My Furniture</h1>
        <p>This is a list of your publications.</p>
    </div>
</div>
<div class="row space-top">
    ${allFurniture.map(f => furnitureTemplate(f))}
</div>`;

async function getView(context) {
    let userId = authService.getUserId();
    let allFurniture = await furnitureService.getMyFurniture(userId);

    let result = myFurnitureTemplate(allFurniture);

    context.renderView(result);
}

export default {
    getView
}