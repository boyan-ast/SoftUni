import { jsonRequester } from "../helpers/jsonRequester.js";

// Change the end of the url
let baseUrl = 'http://localhost:3030/data/memes';

async function getOne(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`);
    return result;
}

async function getAll() {
    let result = await jsonRequester(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
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

async function getMyObjects(userId){
    let result = await jsonRequester(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

export default {
    getAll,
    getOne,
    create,
    update,
    deleteOne,
    getMyObjects
}