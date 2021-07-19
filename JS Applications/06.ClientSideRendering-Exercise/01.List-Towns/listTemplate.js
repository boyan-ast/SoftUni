import { html } from '../node_modules/lit-html/lit-html.js';

export const listTemplate = (townsArr) => html`
<ul>
    ${townsArr.map(town => html`<li>${town}</li>`)}
</ul>`;