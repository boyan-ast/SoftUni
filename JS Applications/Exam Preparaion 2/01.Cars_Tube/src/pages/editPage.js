import { html } from '../../node_modules/lit-html/lit-html.js';

import carsService from '../services/carsService.js';

let editPageTemplate = (form) => html`
<section id="edit-listing">
    <div class="container">

        <form @submit="${form.onSubmit}" id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value="${form.car.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value="${form.car.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value="${form.car.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value="${form.car.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value="${form.car.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value="${form.car.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;
    let car = await carsService.getOne(id);

    let form = {
        car,
        onSubmit
    }

    let result = editPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let brand = formData.get('brand');
        let model = formData.get('model');
        let description = formData.get('description');
        let year = formData.get('year');
        let imageUrl = formData.get('imageUrl');
        let price = formData.get('price');

        if (brand == '' || model == '' || description == '' || year == '' || imageUrl == '' || price == '') {
            alert('All fields must be filled!');
            return;
        }

        let car = {
            brand,
            model,
            description,
            year: Number(year),
            imageUrl,
            price: Number(price)
        }

        try {
            let response = await carsService.update(car, id);
            context.page.redirect(`/details/${id}`);
        } catch(e) {
            alert(e.message);
        }
    }
}

export default {
    getView
}