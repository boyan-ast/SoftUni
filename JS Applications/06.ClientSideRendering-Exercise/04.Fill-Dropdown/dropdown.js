import { render } from '../node_modules/lit-html/lit-html.js';
import { selectTemplate } from './templates/dropdownTemplate.js';

let divElement = document.getElementById('dropdown-menu');
let formElement = document.querySelector('article>form');

let towns = [];

getData();

formElement.addEventListener('submit', addTown);

async function addTown(e) {
    e.preventDefault();

    let form = e.currentTarget;

    let formData = new FormData(form);

    let inputText = formData.get('text');

    if (inputText.trim() == '') {
        return;
    }

    let postResponse = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            text: inputText
        })
    });

    if (postResponse.ok) {
        let postData = await postResponse.json();
        towns.push(postData);
        form.reset();
        render(selectTemplate(towns), divElement);
    }
}

async function getData() {
    let response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');

    if (response.ok) {
        let data = await response.json();
        
        towns = Object.values(data);

        render(selectTemplate(towns), divElement);
    }
}