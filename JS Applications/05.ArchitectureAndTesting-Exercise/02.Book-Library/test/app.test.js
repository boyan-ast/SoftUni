const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser, page;
/* Url has to be changed eventually */
let pageUrl = 'http://127.0.0.1:5501/index.html';

describe('Book Library tests', function () {
    this.timeout(10000);

    before(async () => {
        browser = await chromium.launch();
        //browser = await chromium.launch({ headless: false, slowMo: 500 });
    });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe('Test books loading', () => {
        it('Should load all books correctly', async () => {
            await page.route('**/jsonstore/collections/books', route => route.fulfill(
                fakeServerResponse(testBooks)
            ));

            await page.goto(pageUrl);

            let [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks')
            ]);

            let result = await response.json();

            assert.deepEqual(result, testBooks);
        });
        it('Should fill the ul correctly', async () => {
            await page.route('**/jsonstore/collections/books', route => route.fulfill(
                fakeServerResponse(testBooks)
            ));

            await page.goto(pageUrl);

            let [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks')
            ]);

            let firstTitle = await page.textContent('tbody>tr td:nth-child(1)');
            let firstAuthor = await page.textContent('tbody>tr td:nth-child(2)');
            let editBtn = await page.textContent('tbody>tr td:nth-child(3) .editBtn');
            let deleteBtn = await page.textContent('tbody>tr td:nth-child(3) .deleteBtn');

            assert.equal(firstTitle, 'Test Title 1');
            assert.equal(firstAuthor, 'Test Author 1');
            assert.equal(editBtn, 'Edit');
            assert.equal(deleteBtn, 'Delete');

        });
    });
    describe('Test adding book', () => {
        it("Should add book correctly", async () => {
            let requestData = undefined;

            await page.route('**/jsonstore/collections/books', (route, req) => {
                if (req.method().toUpperCase() == 'POST') {
                    requestData = req.postData();
                    route.fulfill(fakeServerResponse(testBook));
                }
            });

            await page.goto(pageUrl);

            await page.fill('input[name="title"]', testBook.title);
            await page.fill('input[name="author"]', testBook.author);

            let [response] = await Promise.all([
                page.waitForResponse("**/jsonstore/collections/books"),
                page.click("#createForm>button")
            ]);

            let result = await response.json();

            assert.deepEqual(result, testBook);
        });
    });

    describe('Test edit book', () => {
        it('Should edit book correctly', async () => {
            await page.route("**/jsonstore/collections/books", (x) => x.fulfill(respList.fillTable));

            await page.goto(pageUrl);

            await Promise.all([
                page.waitForResponse("**/jsonstore/collections/books"),
                page.click("#loadBooks"),
            ]);

            await page.route("**/jsonstore/collections/books/**", (route) => {
                let replies = {
                    get: respList.original,
                    put: respList.edit,
                    delete: respList.del,
                };

                let method = route.request().method();
                route.fulfill(replies[method.toLowerCase()]);
            });

            let [create, edit] = await Promise.all([
                page.isVisible("#createForm"),
                page.isVisible("#editForm"),
            ]);

            assert.equal(create, true);
            assert.equal(edit, false);

            await page.click('tr[data-id="1"] button.editBtn');

            [create, edit] = await Promise.all([
                page.isVisible("form#createForm"),
                page.isVisible("form#editForm"),
            ]);

            assert.equal(create, false);
            assert.equal(edit, true);

            let [title, author] = await Promise.all([
                page.$eval('#editForm > input[name="title"]', (el) => el.value),
                page.$eval('#editForm > input[name="author"]', (el) => el.value),
            ]);

            assert.equal(title, testBooks[1].title);
            assert.equal(author, testBooks[1].author);

            await page.fill('#editForm > input[name="title"]', bookList.edited.title);
            await page.fill('#editForm > input[name="author"]', bookList.edited.author);

            await page.click("#editForm > button");

            [title, author] = await Promise.all([
                page.$eval('#editForm > input[name="title"]', (el) => el.value),
                page.$eval('#editForm > input[name="author"]', (el) => el.value),
            ]);

            assert.equal(title, '');
            assert.equal(author, '');
        });
    });
    describe('Test delete book', () => {
        it('Should delete books correctly', async () => {
            await page.route("**/jsonstore/collections/books*", (route) => {
                let replies = {
                    get: respList.fillTable,
                    delete: respList.del,
                };

                let method = route.request().method();
                route.fulfill(replies[method.toLowerCase()]);
            });

            await page.goto(pageUrl);

            await Promise.all([
                page.waitForResponse("**/jsonstore/collections/books*"),
                page.click("#loadBooks"),
            ]);

            page.on("dialog", (dialog) => {
                dialog.accept();
            });

            await page.route("**/jsonstore/collections/books/1", (route) => {
                assert.equal(route.request().method(), "DELETE");
                route.fulfill(respList.del);
            });

            await page.click('tr[data-id="1"] button.deleteBtn');
        });
    });
});

function fakeServerResponse(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }
}

let testBooks = {
    1: {
        author: 'Test Author 1',
        title: 'Test Title 1'
    },
    2: {
        author: 'Test Author 2',
        title: 'Test Title 2'
    }
}

let testBook = {
    title: 'On the Road',
    author: 'Kerouac',
    _id: 3
}

let bookList = {
    original: {
        id: '10',
        book: {
            author: 'Kerouac',
            title: 'On the Road'
        }
    },
    edited:
    {
        author: 'Clavell',
        title: 'Shogun'
    },
    deleted: {
        author: 'Deleted Author',
        title: 'Deleted Book'
    }
};

let respList = {
    fillTable: {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(testBooks),
    },
    edit: {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bookList.edited),
    },
    original: {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(testBooks[1]),
    },
    del: {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bookList.deleted),
    }

};