import * as api from './api.js';

export async function getIdeas() {
    return await api.get('/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
}