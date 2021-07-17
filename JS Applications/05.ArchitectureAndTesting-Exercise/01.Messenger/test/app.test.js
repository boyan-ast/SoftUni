const { chromium } = require('playwright-chromium');
const { expect, assert } = require('chai');

let browser, page;
/* Url has to be changed eventually */
let pageUrl = 'http://127.0.0.1:5500/index.html';

describe('Messenger tests', function () {
    this.timeout(100000);

    before(async () => {
        //browser = await chromium.launch();
        browser = await chromium.launch({ headless: false, slowMo: 2000 });
    });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe('Test load messages', () => {
        it('Should call server correctly', async () => {
            await page.route('**/jsonstore/messenger', route => route.fulfill(
                fakeServerResponse(testMessages)
            ));

            await page.goto(pageUrl);

            let [res] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('input#refresh')
            ]);

            let result = await res.json();
            console.log(result);

            expect(result).to.eql(testMessages);
        });
        it('Should fill textarea correctly', async () => {
            await page.route('**/jsonstore/messenger', route => route.fulfill(
                fakeServerResponse(testMessages)
            ));

            await page.goto(pageUrl);

            let [res] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('input#refresh')
            ]);

            let resultText = await page.$eval('#messages', t => t.value);

            let expected = Object.values(testMessages)
                .map(m => `${m.author}: ${m.content}`)
                .join('\n');

            expect(resultText).to.be.equal(expected);
        });
    });
    describe('Test send messages', () => {
        it('Should call server correctly', async () => {
            let requestData = undefined;

            await page.route('**/jsonstore/messenger', (route, req) => {
                if (req.method().toUpperCase() == 'POST') {
                    requestData = req.postData();
                    route.fulfill(fakeServerResponse(testSendMessage));
                }
            });

            await page.goto(pageUrl);
            await page.fill('#author', testSendMessage.test3.author);
            await page.fill('#content', testSendMessage.test3.content);

            let [res] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit')
            ]);

            let expected = {
                author: testSendMessage.test3.author,
                content: testSendMessage.test3.content
            }

            let result = JSON.parse(requestData);
            console.log(result);

            expect(result).to.eql(expected);
        });
        it('Should clear input elements', async () => {
            let requestData = undefined;

            await page.route('**/jsonstore/messenger', (route, req) => {
                if (req.method().toUpperCase() == 'POST') {
                    requestData = req.postData();
                    route.fulfill(fakeServerResponse(testSendMessage));
                }
            });

            await page.goto(pageUrl);
            await page.fill('#author', testSendMessage.test3.author);
            await page.fill('#content', testSendMessage.test3.content);

            let [res] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit')
            ]);

            let author = await page.$eval('#author', a => a.value);
            let content = await page.$eval('#content', c => c.value);

            expect(author).to.equal('');
            expect(content).to.equal('');
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

let testMessages = {
    test1: {
        author: 'Test 1',
        content: 'Test message 1'
    },
    test2: {
        author: 'Test 2',
        content: 'Test message 2'
    }
}

let testSendMessage = {
    test3: {
        author: 'Test 3',
        content: 'Test message 3',
        _id: 3
    }
}