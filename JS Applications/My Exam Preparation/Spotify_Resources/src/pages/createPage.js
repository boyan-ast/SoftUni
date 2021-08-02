import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import songsService from '../services/songsService.js';

let createPageTemplate = (form) => html`
<section id="createSongView">
    <div class="background-spotify">
        <div class="song-container">
            <h1>Create new song</h1>
            <form @submit="${form.onSubmit}">
                <div class="form-group">
                    <label for="title" class="white-labels">Title</label>
                    <input id="title" type="text" name="title" class="form-control" placeholder="Title">
                </div>
                <div class="form-group">
                    <label for="artist" class="white-labels">Artist</label>
                    <input id="artist" type="text" name="artist" class="form-control" placeholder="Artist">
                </div>
                <div class="form-group">
                    <label for="imageURL" class="white-labels">imageURL</label>
                    <input id="imageURL" type="text" name="imageURL" class="form-control" placeholder="imageURL">
                </div>
                <button type="submit" class="btn btn-primary">Create</button>
            </form>
        </div>
    </div>
</section>`;

function getView(context) {
    let form = {
        onSubmit
    };

    let result = createPageTemplate(form);

    context.renderView(result);

    async function onSubmit(e) {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);
        let title= formData.get('title');
        let artist= formData.get('artist');
        let imageUrl= formData.get('imageURL');

        if (title.length < 3 || artist.length < 3 || imageUrl == '') {
            alert('Invalid input!');
            return;
        }

        let newSong = {
            title,
            artist,
            imageUrl,
            listenCount: 0
        };

        let res = await songsService.create(newSong);

        context.page.redirect('/all-songs');
    }
}

export default {
    getView
}