import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import furnitureService from '../services/furnitureService.js';

let editPageTemplate = (form) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit="${form.onSubmit}">
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="form-control ${form.fields.make}" id="new-make" type="text" name="make" .value="${form.furniture.make}">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class="form-control ${form.fields.model}" id="new-model" type="text" name="model" .value="${form.furniture.model}">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class="form-control ${form.fields.year}" id="new-year" type="number" name="year" .value="${form.furniture.year}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class="form-control ${form.fields.description}" id="new-description" type="text" name="description" .value="${form.furniture.description}">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class="form-control ${form.fields.price}" id="new-price" type="number" name="price" .value="${form.furniture.price}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class="form-control ${form.fields.img}" id="new-image" type="text" name="img" .value="${form.furniture.img}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material" .value="${form.furniture.material}">
            </div>
            <input type="submit" class="btn btn-info" value="Edit" />
        </div>
    </div>
</form>`;

async function getView(context) {
    let id = context.params.id;
    let furniture;

    try {
        furniture = await furnitureService.getOne(id);
    } catch (error) {
        alert(error.message);
    }

    let form = {
        onSubmit,
        fields: {
            make: 'initial',
            model: 'initial',
            year: 'initial',
            description: 'initial',
            price: 'initial',
            img: 'initial'
        },
        furniture
    };

    let result = editPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let make = formData.get('make');
        let model = formData.get('model');
        let year = Number(formData.get('year'));
        let description = formData.get('description');
        let price = Number(formData.get('price'));

        let img = formData.get('img');

        if (make.length < 4) {
            form.fields.make = 'is-invalid';
        } else {
            form.fields.make = 'is-valid';
        }
        
        if (model.length < 4) {
            form.fields.model = 'is-invalid';
        } else {
            form.fields.model = 'is-valid';
        }

        if (year >= 1950 && year <= 2050) {
            form.fields.year = 'is-valid';
        } else {
            form.fields.year = 'is-invalid';
        }

        if (description.length < 10) {
            form.fields.description = 'is-invalid';
        } else {
            form.fields.description = 'is-valid';
        }

        if (price <= 0) {
            form.fields.price = 'is-invalid';
        } else {
            form.fields.price = 'is-valid';
        }

        if (img == '') {
            form.fields.img = 'is-invalid';
        } else {
            form.fields.img = 'is-valid';
        }

        if (Object.values(form.fields).some(v => v === 'is-invalid')) {
            let result = editPageTemplate(form);

            return context.renderView(result);
        }

        let material = formData.get('material');

        let editedFurniture = {
            make, model, year, description, price, img, material
        };

        try {
            let response = await furnitureService.update(editedFurniture, id);
            context.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}