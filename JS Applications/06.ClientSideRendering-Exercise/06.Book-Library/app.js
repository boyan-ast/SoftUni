import { render } from '../node_modules/lit-html/lit-html.js';
import { layout, addFormTemplate, editFormTemplate } from './templates/booksTemplate.js';
import { getAllBooks, getBookById, deleteBook, updateBook, createBook } from './data.js';

let rootElement = document.querySelector('.root');
let formsElement = document.querySelector('.forms');

let context = {
    load,
    onButtonClick
}

let formContext = {
    editBook,
    addBook
}

updateView([]);

async function load() {
    let list = await getAllBooks();
    render(layout(context, list), rootElement);
}

async function onButtonClick(e) {
    e.preventDefault();
    let element = e.target;
    if (element.classList.contains('editBtn')) {
        let id = element.parentElement.dataset.id;
        let book = await getBookById(id);
        book._id = id;
        render(editFormTemplate(book, formContext), formsElement);
    } else if (element.classList.contains('deleteBtn')) {
        let id = element.parentElement.dataset.id;
        await deleteBook(id);
        let list = await getAllBooks();
        render(layout(context, list), rootElement);
    }
}

async function editBook(e) {
    e.preventDefault();
    let formElement = e.target.parentElement;
    let formData = new FormData(formElement);
    let id = formData.get('id');     

    await updateBook(id, {
        author: formData.get('author'),
        title: formData.get('title')
    });

    let list = await getAllBooks();
    updateView(list);
}

async function addBook(e) {
    e.preventDefault();
    let formElement= e.target.parentElement;

    let formData = new FormData(formElement);

    let title = formData.get('title');
    let author = formData.get('author');

    await createBook({
        title, 
        author
    });

    let list = await getAllBooks();   
    updateView(list);
}

function updateView(list) {
    render(layout(context, list), rootElement);
    render(addFormTemplate(formContext), formsElement);
}