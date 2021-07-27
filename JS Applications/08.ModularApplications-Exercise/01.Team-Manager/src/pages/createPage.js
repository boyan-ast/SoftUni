import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';

import authService from '../services/authService.js';
import teamsService from '../services/teamsService.js';

let createTemplate = (form) => html`
            <section id="create">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>New Team</h1>
                    </header>
                    <form @submit="${form.onSubmit}" id="create-form" class="main-form pad-large">
                        <div class="error ${ifDefined(form.isInvalid ? undefined : " hidden")}">Error message.</div>
                        <label>Team name: <input type="text" name="name"></label>
                        <label>Logo URL: <input type="text" name="logoUrl"></label>
                        <label>Description: <textarea name="description"></textarea></label>
                        <input class="action cta" type="submit" value="Create Team">
                    </form>
                </article>
            </section>`;

function getView(context) {
    let form = {
        onSubmit,
        isInvalid: false
    }

    let result = createTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let name = formData.get('name');
        let logoUrl = formData.get('logoUrl');
        let description = formData.get('description');

        if (name.length < 4 || logoUrl == '' || description.length < 10) {
            form.isInvalid = true;

            result = createTemplate(form);

            return context.renderView(result);
        }

        let newTeam = await teamsService.create({name, logoUrl, description});

        let teamId = newTeam._id;
        let ownerId = newTeam._ownerId;

        let newMember = {
            _id: ownerId,
            teamId,
        }

        let newMemberResponse = await teamsService.addMemberToTeam(newMember);

        console.log(newMemberResponse);
    }
}

export default {
    getView
}