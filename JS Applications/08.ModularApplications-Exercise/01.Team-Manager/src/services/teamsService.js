import { jsonRequest } from "../helpers/jsonRequest.js";

let baseUrl = 'http://localhost:3030/data/teams';

async function getAll(){
    let result = await jsonRequest(baseUrl);
    return result;
}

async function getOne(id){
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function create(item){
    let result = await jsonRequest(`${baseUrl}`, 'POST', item, true);
    return result;
}

async function update(item, id){
    let result = await jsonRequest(`${baseUrl}/${id}`, 'PUT', item, true);
    return result;
}

async function deleteItem(id){
    let result = await jsonRequest(`${baseUrl}/${id}`, 'DELETE', undefined, true);
    return result;
}

async function getAllMembers(){
    //let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    let result = await jsonRequest(`${baseUrl}?where=status%3D%22member%22`);
    return result;
}

async function getAllMembersInTeam(teamId) {
        let result = await jsonRequest(`${baseUrl}?where=teamId%3D%22${teamId}%22&status="member"`);
        return result;    
}

export default {
    getAll,
    getOne,
    create,
    update,
    deleteItem,
    getAllMembers,
    getAllMembersInTeam
}