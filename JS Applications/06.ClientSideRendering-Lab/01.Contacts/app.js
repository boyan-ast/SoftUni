import { contacts } from "./contacts.js";
import { render } from '../node_modules/lit-html/lit-html.js';
import { cardTemplate } from './card.js';

let contactsDivElement = document.getElementById('contacts');

let result = contacts.map(cardTemplate);

render(result, contactsDivElement);