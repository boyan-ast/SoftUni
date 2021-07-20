import { render } from '../node_modules/lit-html/lit-html.js';
import { tableTemplate } from './templates/tableTemplate.js';

let tbodyElement = document.querySelector('.container tbody');

let peopleInfo = [];

getData();

let searchInputElement = document.getElementById('searchField');
let searchButton = document.getElementById('searchBtn');

searchButton.addEventListener('click', search);

function search(e) {
   let searchValue = searchInputElement.value;

   if (searchValue.trim() == '') {
      return;
   }

   let people = peopleInfo.map(x => Object.assign({}, x));

   let selectedPeople = people.filter(p =>
      Object.values(p).some(v => v.toLowerCase().includes(searchValue.toLowerCase())));

   selectedPeople.forEach(p => p.class = 'select');

   searchInputElement.value = '';

   render(tableTemplate(people), tbodyElement);
}

async function getData() {
   let response = await fetch('http://localhost:3030/jsonstore/advanced/table');

   if (response.ok) {
      let peopleInfoObj = await response.json();
      peopleInfo = Object.values(peopleInfoObj);

      render(tableTemplate(peopleInfo), tbodyElement);
   }
}