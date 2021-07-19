import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

let liTemplate = (town, match) => html`
<li class=${(match && town.toLowerCase().includes(match.toLowerCase())) ? 'active' : '' }>${town}</li>`;

let townsTemplate = (towns, match, clicked) => html`
<article>
      <div id="towns">
         <ul>
            ${towns.map(t => liTemplate(t, match))}
         </ul>
      </div>
      <input type="text" id="searchText" />
      <button @click=${search}>Search</button>
      <div id="result" class=${clicked ? '' : 'hidden'}>${towns.filter(t => (match && t.toLowerCase().includes(match.toLowerCase()))).length + ' matches found'}</div>
</article>`;

let bodyElement = document.querySelector('body');

update();

function search(e) {
   update(e.target.previousElementSibling.value, true);
}

function update(match = '', clicked = false) {
   render(townsTemplate(towns, match, clicked), bodyElement);
}
