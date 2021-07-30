import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import furnitureService from '../services/furnitureService.js';

let detailsPageTemplate = (furniture, onDeleteClick) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${furniture.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${furniture.make}</span></p>
        <p>Model: <span>${furniture.model}</span></p>
        <p>Year: <span>${furniture.year}</span></p>
        <p>Description: <span>${furniture.description}</span></p>
        <p>Price: <span>${furniture.price}</span></p>
        <p>Material: <span>${furniture.material}</span></p>
        ${authService.currentUserIsOwner(furniture._ownerId) ?
        html`
        <div>
            <a href="/edit/${furniture._id}" class="btn btn-info">Edit</a>
            <a href='javascript:void(0)' @click="${onDeleteClick}" class="btn btn-red">Delete</a>
        </div>` : ''}
    </div>
</div>`;

async function getView(context) {
    let id = context.params.id;

    let furniture;

    try {
        furniture = await furnitureService.getOne(id);
    } catch (error) {
        alert(error.message);
    }

    let result = detailsPageTemplate(furniture, onDeleteClick);

    context.renderView(result);

    async function onDeleteClick(e) {
        e.preventDefault();

        try {
            await furnitureService.deleteOne(id);
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}