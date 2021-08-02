import authService from '../services/authService.js';

export async function jsonRequester(url, method, body, isAuthorized, resultSkip) {
    let result = undefined;

    if (method === undefined) {
        method = 'GET';
    }

    let headers = {};

    if (method.toUpperCase() === 'POST' || 
        method.toUpperCase() === 'PUT' || 
        method.toUpperCase() === 'PATCH') {
        headers['Content-Type'] = 'application/json';
    }

    if (isAuthorized === true) {
        headers['X-Authorization'] = authService.getToken();
    }

    let options = {
        headers,
        method
    };

    if (body !== undefined) {
        options.body = JSON.stringify(body);
    }

    let response = await fetch(url, options);
    
    if (!response.ok) {
        throw new Error(`Fetch failed! Error: ${response.status}, ${response.statusText}`);
    }
    
    if (!resultSkip) {
        result = await response.json();
    }

    return result;
}