import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import teamsService from '../services/teamsService.js';

let singleTeamTemplate = (team) => html`
                <article class="layout">
                    <img src="${team.logoUrl}" class="team-logo left-col">
                    <div class="tm-preview">
                        <h2>${team.name}</h2>
                        <p>${team.description}</p>
                        <span class="details">${team.members.length} Members</span>
                        <div><a href="/details/${team._id}" class="action">See details</a></div>
                    </div>
                </article>`;

let browseTemplate = (allTeams) => html`
            <section id="browse">
            
                <article class="pad-med">
                    <h1>Team Browser</h1>
                </article>
            
                ${authService.isLoggedIn() ?
                html`
                <article class="layout narrow">
                    <div class="pad-small"><a href="#" class="action cta">Create Team</a></div>
                </article>`: 
                ''}
                ${allTeams.map(t => singleTeamTemplate(t))}                        
            
            </section>`;

async function getView(context) {
    let allTeams = await teamsService.getAll();

    for (const team of allTeams) {
        let teamMembers = await getTeamMembers(team._id);
        team.members = teamMembers;
    }

    let result = browseTemplate(allTeams);

    context.renderView(result);

    async function getTeamMembers(teamId) {
        return await teamsService.getAllMembersInTeam(teamId);
    }
}

export default {
    getView
}