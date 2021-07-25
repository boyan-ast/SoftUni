import { html } from "../../node_modules/lit-html/lit-html.js";

import furnitureService from "../services/furnitureService.js";

let createTemplate = (form) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${form.onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="form-control ${form.invalidFields.make}" id="new-make" type="text" name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class="form-control ${form.invalidFields.model}" id="new-model" type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class="form-control ${form.invalidFields.year}" id="new-year" type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class="form-control ${form.invalidFields.description}" id="new-description" type="text"
                    name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class="form-control ${form.invalidFields.price}" id="new-price" type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class="form-control ${form.invalidFields.img}" id="new-image" type="text" name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Create" />
        </div>
    </div>
</form>`;

async function getView(context) {
    let form = {
        onSubmit,
        invalidFields: {
            make: "initial",
            model: "initial",
            year: "initial",
            description: "initial",
            price: "initial",
            img: "initial"
        }
    };

    let result = createTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let make = formData.get('make');
        let model = formData.get('model');
        let year = formData.get('year');
        year = Number(year);
        let description = formData.get('description');
        let price = formData.get('price');
        price = Number(price);
        let img = formData.get('img');
        let material = formData.get('material');

        make.length >= 4 ? 
            form.invalidFields.make = 'is-valid' : 
            form.invalidFields.make = 'is-invalid';
        model.length >= 4 ? 
            form.invalidFields.model = 'is-valid' : 
            form.invalidFields.model = 'is-invalid';

        if (year >= 1950 && year <= 2050) {
            form.invalidFields.year = 'is-valid';
        } else {
            form.invalidFields.year = 'is-invalid';
        }

        description.length > 10 ? 
            form.invalidFields.description = 'is-valid' : 
            form.invalidFields.description = 'is-invalid';

        if (price > 0) {
            form.invalidFields.price = 'is-valid';
        } else {
            form.invalidFields.price = 'is-invalid';
        }

        img.trim() !== '' ? 
            form.invalidFields.img = 'is-valid' : 
            form.invalidFields.img = 'is-invalid';

        if (Object.values(form.invalidFields).some(f => f === 'is-invalid')) {
            let result = createTemplate(form);

            return context.renderView(result);
        }

        let newFurniture = {
            make,
            model,
            year,
            description,
            price,
            img,
            material
        }

        let response = await furnitureService.create(newFurniture);

        context.page.redirect('/dashboard');
    }
}

export default {
    getView
}