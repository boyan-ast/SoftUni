import { render } from '../node_modules/lit-html/lit-html.js'
import { listTemplate } from './listTemplate.js';

let formElement = document.querySelector('body>form');
let rootDivElement = document.querySelector('#root');

formElement.addEventListener('submit', listTowns);

function listTowns(e) {
    e.preventDefault();

    let formData = new FormData(formElement);

    let townsArr = formData.get('towns').split(', ').filter(t => t != '');

    render(listTemplate(townsArr), rootDivElement);

    e.target.reset();
}   