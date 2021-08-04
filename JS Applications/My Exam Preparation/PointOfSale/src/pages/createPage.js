import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import productsService from '../services/productsService.js';

let singleProductTemplate = (product, onDeleteClick) => html`
<div class="row" data-id="${product._id}">
    <div class="col wide">${product.name}</div>
    <div class="col wide">${product.quantity}</div>
    <div class="col wide">${product.price.toFixed(2)}</div>
    <div class="col">${(product.quantity * product.price).toFixed(2)}</div>
    <div class="col right">
        ${(authService.isLoggedIn() && authService.currentUserIsOwner(product._ownerId)) ? 
        html`        
        <a href="/edit/${product._id}">Edit</a>
        <a href="javascript:void(0)" @click="${onDeleteClick}">&#10006;</a>` : ''}              

    </div>
</div>`;

let productsPageTemplate = (allProducts, onAddClick, onDeleteClick, totalPrice) => html`
<section id="create-receipt-view">
    <h1>Create Receipt</h1>
    <div class="table">
        <div class="table-head">
            <div class="col wide">Product Name</div>
            <div class="col wide">Quantity</div>
            <div class="col wide">Price per Unit</div>
            <div class="col">Sub-total</div>
            <div class="col">Action</div>
        </div>
        <div id="active-entries">
            ${allProducts.map(p => singleProductTemplate(p, onDeleteClick))}         
        </div>
        <div class="row">
            ${authService.isLoggedIn() ?
            html`
            <form @submit="${onAddClick}" id="create-entry-form">
                <div class="col wide">
                    <input name="type" placeholder="Product name">
                </div>
                <div class="col wide">
                    <input name="qty" placeholder="Quantity">
                </div>
                <div class="col wide">
                    <input name="price" placeholder="Price per Unit">
                </div>
                <div class="col">Sub-total</div>
                <div class="col">
                    <input id="addItemBtn" type="submit" value="Add" />
                </div>
            </form>` : ''}            
        </div>
        <div class="table-foot">
            <form id="create-receipt-form">
                <div class="col wide">
                </div>
                <div class="col wide">
                </div>
                <div class="col wide right">Total:</div>
                <div class="col">${totalPrice.toFixed(2)}</div>
            </form>
        </div>
    </div>
</section>`;

async function getView(context) {
    let allProducts = await productsService.getAll();

    let totalPrice = allProducts.reduce((acc, p) => acc + (p.price*p.quantity), 0);

    let result = productsPageTemplate(allProducts, onAddClick, onDeleteClick, totalPrice);

    context.renderView(result);

    async function onAddClick(e) {
        e.preventDefault();
        let formElement = e.currentTarget;

        let formData = new FormData(formElement);
        let name = formData.get('type');
        let quantity = formData.get('qty');
        let price = formData.get('price');

        if (name == '' || quantity == '' || price == '') {
            alert('All fileds must be filled!');
            return;
        }

        let response = await productsService.create({
            name,
            quantity: Number(quantity),
            price: Number(price)
        });

        formElement.reset();
        context.page.redirect('/overview');
    }

    async function onDeleteClick(e) {
        e.preventDefault();

        let id = e.target.parentElement.parentElement.dataset.id;

        await productsService.deleteOne(id);

        context.page.redirect('/overview');
    }
}

export default {
    getView
}