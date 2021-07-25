import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";
import furnitureService from "../services/furnitureService.js";

let detailsTemplate = (furniture) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=${'.' + furniture.img} />
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

        ${authService.getUserId() === furniture._ownerId ?
        html`
        <div>
            <a href='/edit/${furniture._id}' class="btn btn-info">Edit</a>
            <a href='javascript:void(0)' class="btn btn-red" @click=${furniture.onDeleteClick}>Delete</a>
        </div>` :
            html` `}
    </div>
</div>`;

async function getView(context) {
    let furnitureId = context.params.id;

    let furniture = await furnitureService.getOne(furnitureId);

    furniture.onDeleteClick = deleteHandler;

    let result = detailsTemplate(furniture);

    context.renderView(result);

    async function deleteHandler(e) {
        e.preventDefault();

        let confirmed = confirm('Are you sure?')

        if(confirmed) {
            furnitureService.deleteItem(furnitureId);

            context.page.redirect('/dashboard');
        }
    }
}

export default {
    getView
}