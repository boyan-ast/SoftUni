import { jsonRequester } from "../helpers/jsonRequester.js";

let baseUrl = 'http://localhost:3030/users';

async function login(user) {
    let result = await jsonRequester(`${baseUrl}/login`, 'POST', user);
    localStorage.setItem('token', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('email', result.email);

    // localStorage.setItem('username', result.username);
    // localStorage.setItem('gender', result.gender);

    return result;
}

async function register(user) {
    let result = await jsonRequester(`${baseUrl}/register`, 'POST', user);
    localStorage.setItem('token', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('email', result.email);

    // localStorage.setItem('username', result.username);
    // localStorage.setItem('gender', result.gender);

    return result;
}

function getToken() {
    return localStorage.getItem('token');
}

function getEmail() {
    return localStorage.getItem('email');
}

// function getUsername() {
//     return localStorage.getItem('username');
// }

// function getGender() {
//     return localStorage.getItem('gender');
// }

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('token') !== null;
}

async function logout() {
    await jsonRequester(`${baseUrl}/logout`, 'GET', undefined, true, true);
    localStorage.clear();
}

function currentUserIsOwner(itemOwnerId) {
    return localStorage.getItem('userId') === itemOwnerId;
}

export default {
    getToken,
    getUserId,
    getEmail,
    isLoggedIn,
    login,
    register,
    logout,
    currentUserIsOwner,
    // getUsername,
    // getGender
}