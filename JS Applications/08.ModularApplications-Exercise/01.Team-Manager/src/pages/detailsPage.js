import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import teamsService from '../services/teamsService.js';

let detailsTemplate = (team) => html`
            <section id="team-home">
                <article class="layout">
                    <img src="${team.logoUrl}" class="team-logo left-col">
                    <div class="tm-preview">
                        <h2>${team.name}</h2>
                        <p>${team.description}</p>
                        <span class="details">${team.members.length} Members</span>
                        <div>
                            ${authService.getUserId() == team._ownerId ?
                                html`<a href="/edit/${team._id}" class="action">Edit team</a>` :
                                ''
                            }
                            <a href="/join/${team._id}" class="action">Join team</a>
                            <a href="#" class="action invert">Leave team</a>
                            Membership pending. <a href="#">Cancel request</a>
                        </div>
                    </div>
                    <div class="pad-large">
                        <h3>Members</h3>
                        <ul class="tm-members">
                            <li>My Username</li>
                            <li>James<a href="#" class="tm-control action">Remove from team</a></li>
                            <li>Meowth<a href="#" class="tm-control action">Remove from team</a></li>
                        </ul>
                    </div>
                    <div class="pad-large">
                        <h3>Membership Requests</h3>
                        <ul class="tm-members">
                            <li>John<a href="#" class="tm-control action">Approve</a><a href="#"
                                    class="tm-control action">Decline</a></li>
                            <li>Preya<a href="#" class="tm-control action">Approve</a><a href="#"
                                    class="tm-control action">Decline</a></li>
                        </ul>
                    </div>
                </article>
            </section>`;

async function getView(context) {
    let teamId = context.params.id;

    let team = await teamsService.getOne(teamId);
    let teamMembers = await teamsService.getAllMembersInTeam(teamId);
    team.members = teamMembers;
    console.log(team);

    let result = detailsTemplate(team);

    context.renderView(result);
}

export default {
    getView
}