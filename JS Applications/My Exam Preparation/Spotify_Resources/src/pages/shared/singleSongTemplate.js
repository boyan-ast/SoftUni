import { html } from '../../../node_modules/lit-html/lit-html.js';
import authService from '../../services/authService.js';

export let singleSongTemplate = (song, onRemoveClick, onListenClick) => html`
<div class="song" data-id="${song._id}">
    <h5>Title: ${song.title}</h5>
    <h5>Artist: ${song.artist}</h5>
    <img class="cover" src="${song.imageUrl}" />
    ${authService.currentUserIsOwner(song._ownerId) ?
        html`
    <p>Listened ${song.listenCount} times</p>
    <a @click="${onRemoveClick}" href="javascript:void(0)"><button type="button" class="btn btn-danger mt-4">Remove</button></a>
    <a @click="${onListenClick} "href="javascript:void(0)"><button type="button" class="btn btn-success mt-4">Listen</button></a>` :
        html`
    <p>Listened ${song.listenCount} times</p>`}
</div>`;