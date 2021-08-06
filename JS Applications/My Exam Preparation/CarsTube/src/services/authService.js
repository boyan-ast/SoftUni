import { jsonRequester } from "../helpers/jsonRequester.js";

let baseUrl = 'http://localhost:3030/users';

async function login(user) {
    let result = await jsonRequester(`${baseUrl}/login`, 'POST', user);
    localStorage.setItem('token', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('username', result.username);

    return result;
}

async function register(user) {
    let result = await jsonRequester(`${baseUrl}/register`, 'POST', user);
    localStorage.setItem('token', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('username', result.username);

    return result;
}

function getToken() {
    return localStorage.getItem('token');
}

function getUsername() {
    return localStorage.getItem('username');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('token') !== null;
}

function currentUserIsOwner(itemOwnerId) {
    return localStorage.getItem('userId') === itemOwnerId;
}

async function logout() {
    await jsonRequester(`${baseUrl}/logout`, 'GET', undefined, true, true);
    localStorage.clear();
}

export default {
    getToken,
    getUserId,
    isLoggedIn,
    login,
    register,
    logout,
    currentUserIsOwner,
    getUsername
}