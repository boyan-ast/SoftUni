import { jsonRequester } from "../helpers/jsonRequester.js";

let baseUrl = 'http://localhost:3030/data/furniture';

async function getOne(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`);
    return result;
}

async function getAll() {
    let result = await jsonRequester(baseUrl);
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

export default {
    getAll,
    getOne,
    create,
    update,
    deleteOne
}