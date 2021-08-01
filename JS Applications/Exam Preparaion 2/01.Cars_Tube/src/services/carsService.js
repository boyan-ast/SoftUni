import { jsonRequester } from "../helpers/jsonRequester.js";

let baseUrl = 'http://localhost:3030/data/cars';

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

async function getMyCars(userId){
    let result = await jsonRequester(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

async function getCarsByYear(input) {
    let result = await jsonRequester(`${baseUrl}?where=year%3D${input}`);

    return result;
}

export default {
    getAll,
    getOne,
    create,
    update,
    deleteOne,
    getMyCars,
    getCarsByYear
}