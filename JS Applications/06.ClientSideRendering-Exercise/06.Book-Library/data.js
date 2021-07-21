const host = 'http://localhost:3030/jsonstore/collections/books';

export async function request(url, options) {
    let response = await fetch(url, options);
    let data = await response.json();

    return data;
}

export async function getAllBooks() {
    return Object
        .entries(await request(host))
        .map(([key, value]) => Object.assign(value, {_id: key}));
}

export async function getBookById(id) {
    return await request(host + '/' + id);
}

export async function createBook(book) {
    return await request(host, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    });
}

export async function updateBook(id, book) {
    return await request(host + '/' + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    });
}

export async function deleteBook(id) {
    return await request(host + '/' + id, {
        method: 'delete',
    });
}