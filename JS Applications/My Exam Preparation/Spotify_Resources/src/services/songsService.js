import { jsonRequester } from "../helpers/jsonRequester.js";

// Change the end of the url
let baseUrl = 'http://localhost:3030/data/songs';

async function getOne(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`);
    return result;
}

async function getAll(context) {
    try {
        let result = await jsonRequester(baseUrl);
        return result;
    } catch (error) {
        context.page.redirect('/create');
    }
}

async function create(item) {
    let result = await jsonRequester(`${baseUrl}`, 'POST', item, true);
    return result;
}

async function update(item, id) {
    let result = await jsonRequester(`${baseUrl}/${id}`, 'PUT', item, true);
    return result;
}

async function deleteOne(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`, 'DELETE', undefined, true);
    return result;
}

async function likeSong(id) {
    let song = await getOne(id);
    song.likes++;

    let result = await update(song, id);
    return result;
}

async function listenSong(id) {
    let song = await getOne(id);
    song.listenCount++;

    let result = await update(song, id);
    return result;
}

async function getMySongs(userId){
    try {
        let result = await jsonRequester(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
        return result;
    } catch (error) {
        context.page.redirect('/create');
    }
}

export default {
    getAll,
    getOne,
    create,
    update,
    deleteOne,
    likeSong,
    listenSong,
    getMySongs
}