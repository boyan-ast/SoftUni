import authService from '../services/authService.js';

export async function jsonRequester(url, method, body, isAuthorized, resultSkip) {
    if (method === undefined) {
        method = 'GET';
    }

    let headers = {};

    if (['POST', 'PUT', 'PATCH'].includes(method.toUpperCase())) {
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

    let result = undefined;
    
    if (!resultSkip) {
        result = await response.json();
    }

    return result;
}