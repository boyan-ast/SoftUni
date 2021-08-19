import { jsonRequester } from "../helpers/jsonRequester.js";
import authService from "./authService.js";

let baseUrl = 'http://localhost:3030/data/books';
let likesUrl = 'http://localhost:3030/data/likes';

async function getBook(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`);
    return result;
}

async function getAllBooks() {
    let result = await jsonRequester(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}

async function createBook(item) {
    let result = await jsonRequester(`${baseUrl}`, 'POST', item, true);
    return result;
}

async function updateBook(item, id) {
    let result = await jsonRequester(`${baseUrl}/${id}`, 'PUT', item, true);
    return result;
}

async function deleteBook(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`, 'DELETE', undefined, true);
    return result;
}

async function getMyBooks(userId){
    let result = await jsonRequester(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

async function likeBook(item) {
    let result = await jsonRequester(`${likesUrl}`, 'POST', item, true);
    return result;
}

async function getBookLikes(bookId) {
    let result = await jsonRequester(`${likesUrl}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
    return result;
}

async function currentUserLikedBook(bookId){
    if(authService.isLoggedIn()) {
        let userId = authService.getUserId();

        let result = await jsonRequester(`${likesUrl}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
    
        return result == 1;
    }

    return false;
}

export default {
    getAllBooks,
    getBook,
    createBook,
    updateBook,
    deleteBook,
    getMyBooks,
    likeBook,
    getBookLikes,
    currentUserLikedBook
}