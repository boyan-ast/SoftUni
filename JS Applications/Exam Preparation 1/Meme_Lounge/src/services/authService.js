import { jsonRequest } from "../helpers/jsonRequest.js";

let baseUrl = 'http://localhost:3030/users';

function getAuthToken() {
    return localStorage.getItem('authToken');
}

function getEmail() {
    return localStorage.getItem('email');
}

function getUsername() {
    return localStorage.getItem('username');
}

function getGender() {
    return localStorage.getItem('gender');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('authToken') !== null;
}

async function login(user) {
    let result = await jsonRequest(`${baseUrl}/login`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('email', result.email);

    //Just for this problem
    localStorage.setItem('username', result.username);
    localStorage.setItem('gender', result.gender);

    return result;
}

async function register(user) {
    let result = await jsonRequest(`${baseUrl}/register`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('email', result.email);

    //Just for this problem
    localStorage.setItem('username', result.username);
    localStorage.setItem('gender', result.gender);

    return result;
}

async function logout(user) {
    await jsonRequest(`${baseUrl}/logout`, 'Get', undefined, true, true);
    localStorage.clear();
}

export default {
    getAuthToken,
    getUserId,
    getEmail,
    isLoggedIn,
    login,
    register,
    logout,
    getUsername,
    getGender
}