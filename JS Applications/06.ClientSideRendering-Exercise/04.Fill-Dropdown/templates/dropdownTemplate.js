import { html } from '../../node_modules/lit-html/lit-html.js';

let optionTemplate = (item) => html`
<option .value=${item._id}>${item.text}</option>`;

export const selectTemplate = (items) => html`
<select id="menu">
     ${items.map(x => optionTemplate(x))}
</select>`;