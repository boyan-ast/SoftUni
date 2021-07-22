import { html } from '../../node_modules/lit-html/lit-html.js';

export let rowTemplate = (book) => html`
<tr>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td data-id=${book._id}>
        <button class="editBtn">Edit</button>
        <button class="deleteBtn">Delete</button>
    </td>
</tr>`;

export let tableTemplate = (data, context) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody @click=${context.onButtonClick}}>
        ${data.map(b => rowTemplate(b))}
    </tbody>
</table>`;

export let addFormTemplate = (formContext) => html`
<form id="add-form">
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit" @click=${formContext.addBook}>
</form>`;

export let editFormTemplate = (book, formContext) => html`
<form id="edit-form">
    <input type="hidden" name="id" .value=${book._id}>
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." .value=${book.title}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." .value=${book.author}>
    <input type="submit" value="Save" @click=${formContext.editBook}>
</form>`;

export let layout = (context, data) => html`
<button @click=${context.load} id="loadBooks">LOAD ALL BOOKS</button>
${tableTemplate(data, context)}`;