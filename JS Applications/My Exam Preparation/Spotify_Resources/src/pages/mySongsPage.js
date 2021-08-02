import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import songsService from '../services/songsService.js';
import { singleSongTemplate } from './shared/singleSongTemplate.js';

let mySongsPageTemplate = (allSongs) => html`
<section id="mySongsView">
    <div class="background-spotify">
        <div class="song-container">
            <h1>My Songs</h1>
            ${allSongs.map(s => singleSongTemplate(s))}
        </div>
    </div>
</section>`;

async function getView(context) {
    let mySongsResponse = await songsService.getMySongs(authService.getUserId());
    let result = mySongsPageTemplate(mySongsResponse, onRemoveClick, onListenClick);

    context.renderView(result);

    async function onRemoveClick(e){
        e.preventDefault();

        let id = e.currentTarget.parentElement.dataset.id;

        await songsService.deleteOne(id);

        context.page.redirect('/my-songs');
    }

    async function onListenClick(e) {
        e.preventDefault();

        let id = e.currentTarget.parentElement.dataset.id;
        let response = await songsService.listenSong(id);
        
        let mySongsResponse = await songsService.getMySongs(authService.getUserId());

        let result = mySongsPageTemplate(mySongsResponse, onRemoveClick, onListenClick);
    
        context.renderView(result);
    }
}

export default {
    getView
}