import { html } from '../../node_modules/lit-html/lit-html.js';

import songsService from '../services/songsService.js';
import { singleSongTemplate } from './shared/singleSongTemplate.js';

let allSongsPageTemplate = (allSongs, onRemoveClick, onListenClick) => html`
<section id="allSongsView">
    <div class="background-spotify">
        <div class="song-container">
            <h1>All Songs</h1>
            <a href="/create">
                <button type="button" class="btn-lg btn-block new-song-btn">Add a new song</button>
            </a>
            ${allSongs.map(s => singleSongTemplate(s, onRemoveClick, onListenClick))}
        </div>
    </div>
</section>`;

async function getView(context) {
    let allSongsResponse = await songsService.getAll(context);

    let result = allSongsPageTemplate(allSongsResponse, onRemoveClick, onListenClick);

    context.renderView(result);

    async function onRemoveClick(e){
        e.preventDefault();

        let id = e.currentTarget.parentElement.dataset.id;

        await songsService.deleteOne(id);

        context.page.redirect('/all-songs');
    }

    async function onListenClick(e) {
        e.preventDefault();

        let id = e.currentTarget.parentElement.dataset.id;
        let response = await songsService.listenSong(id);
        
        let allSongsResponse = await songsService.getAll(context);

        let result = allSongsPageTemplate(allSongsResponse, onRemoveClick, onListenClick);
    
        context.renderView(result);
    }
}

export default {
    getView
}