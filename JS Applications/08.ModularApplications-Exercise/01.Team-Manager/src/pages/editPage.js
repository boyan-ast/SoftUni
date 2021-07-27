import { html } from '../../node_modules/lit-html/lit-html.js';
import teamsService from '../services/teamsService.js';

let editTemplate = (form) => html`
            <section id="edit">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>Edit Team</h1>
                    </header>
                    <form @submit=${form.onSubmit} id="edit-form" class="main-form pad-large">
                        <div class="error hidden">Error message.</div>
                        <label>Team name: <input type="text" name="name" .value=${form.team.name}></label>
                        <label>Logo URL: <input type="text" name="logoUrl". value=${form.team.logoUrl}></label>
                        <label>Description: <textarea name="description" .value=${form.team.description}></textarea></label>
                        <input class="action cta" type="submit" value="Save Changes">
                    </form>
                </article>
            </section>`;

async function getView(context) {
    let id = context.params.id;

    let team = await teamsService.getOne(id);

    let form = {
        team,
        onSubmit
    }

    let result = editTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let name = formData.get('name');
        let logoUrl = formData.get('logoUrl');
        let description = formData.get('description');

        let editResponse = await teamsService.update({name, logoUrl, description}, id);

        context.page.redirect(`/details/${id}`);
    }
}

export default {
    getView
}