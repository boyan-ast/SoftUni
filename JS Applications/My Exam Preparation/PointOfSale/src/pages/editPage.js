import { html } from '../../node_modules/lit-html/lit-html.js';

import productsService from '../services/productsService.js';

let editPageTemplate = (form) => html`
<div class="row">
    <form @submit="${form.onSubmit}" id="create-entry-form">
        <div class="col wide">
            <input name="type" placeholder="Product name" .value=${form.product.name}>
        </div>
        <div class="col wide">
            <input name="qty" placeholder="Quantity" .value=${form.product.quantity}>
        </div>
        <div class="col wide">
            <input name="price" placeholder="Price per Unit" .value=${form.product.price}>
        </div>
        <div class="col">Sub-total</div>
        <div class="col">
            <input id="editBtn" type="submit" value="Edit" />
        </div>
    </form>
</div>`;

async function getView(context) {
    let id = context.params.id;

    let product = await productsService.getOne(id);

    let form = {
        onSubmit,
        product
    };

    let result = editPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let name = formData.get('type');
        let quantity = formData.get('qty');
        let price = formData.get('price');

        if (name == '' || quantity == '' || price == '') {
            alert('All fileds must be filled!');
            return;
        }

        let response = await productsService.update({
            name,
            quantity: Number(quantity),
            price: Number(price)
        }, id);

        context.page.redirect('/overview');
    }
}

export default {
    getView
}