import { html } from '../../node_modules/lit-html/lit-html.js';

import carsService from '../services/carsService.js';

let createPageTemplate = (form) => html`
<section id="create-listing">
    <div class="container">
        <form @submit="${form.onSubmit} " id="create-form">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    }

    let result = createPageTemplate(form);

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

        let newCar = {
            brand,
            model,
            description,
            year: Number(year),
            imageUrl,
            price: Number(price)
        }

        try {
            let response = await carsService.create(newCar);
            context.page.redirect('/all-listings');
        } catch(e) {
            alert(e.message);
        }
    }
}

export default {
    getView
}