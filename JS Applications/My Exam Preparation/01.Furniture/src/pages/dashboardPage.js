import { html } from '../../node_modules/lit-html/lit-html.js';
import furnitureService from '../services/furnitureService.js';
import { singleFurnitureTemplate } from './shared/singleFurnitureTemplate.js';

let dashboardPageTemplate = (allFurniture) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${allFurniture.map(f => singleFurnitureTemplate(f))}
        </div>
`;

async function getView(context) {
    try {
        let allFurniture = await furnitureService.getAll();
        let result = dashboardPageTemplate(allFurniture);

        context.renderView(result);
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}