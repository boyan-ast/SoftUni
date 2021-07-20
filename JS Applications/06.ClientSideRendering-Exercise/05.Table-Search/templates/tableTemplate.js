import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js'

let rowTemplate = (personInfo) => html`
<tr class=${ifDefined(personInfo.class)}>
    <td>${personInfo.firstName} ${personInfo.lastName}</td>
    <td>${personInfo.email}</td>
    <td>${personInfo.course}</td>
</tr>`;

export const tableTemplate = (data) => html`
${data.map(x => rowTemplate(x))}`;