import { html } from '../../node_modules/lit-html/lit-html.js';

import carsService from '../services/carsService.js';

let editPageTemplate = (form, car) => html`
<section id="edit-listing">
    <div class="container">
        <form @submit="${form.onSubmit}" id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value="${car.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value="${car.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value="${car.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value="${car.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value="${car.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value="${car.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

async function getView(context) {
    let id = context.params.id;
    let car;

    try {
        car = await carsService.getOne(id);
    } catch (e) {
        alert(e.message);
        return;
    }

    let form = {
        onSubmit
    };

    let result = editPageTemplate(form, car);

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
            alert('Invalid input!');
            return;
        }

        let editedCar = {
            brand,
            model,
            description,
            year: Number(year),
            imageUrl,
            price: Number(price)
        };

        try {
            let response = await carsService.update(editedCar, id);

            context.page.redirect(`/details/${car._id}`);
        } catch (error) {
            alert(error.message);
        }
    }
}

export default {
    getView
}