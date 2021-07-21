import {render} from '../node_modules/lit-html/lit-html.js';
import {layout} from './templates/booksTemplate.js';

let bodyElement = document.querySelector('body');

let list = [];

render(layout(list), bodyElement);