const lookupChar = require('../03.CharLookup');
const { assert } = require('chai');

describe('Tesh Lookup Char functionality', () => {
    it('Should return undefined when the first parameter is not string', () => {
        assert.isUndefined(lookupChar(123, 1));
        assert.isUndefined(lookupChar(null, 1));
        assert.isUndefined(lookupChar({name: 'Test'}, 1));
        assert.isUndefined(lookupChar(false, 1));
        assert.isUndefined(lookupChar([], 1));
    });
    it('Should return undefined when the second parameter is not integer number', () => {
        assert.isUndefined(lookupChar('test', null));
        assert.isUndefined(lookupChar('test', undefined));
        assert.isUndefined(lookupChar('test', []));
        assert.isUndefined(lookupChar('test', '1'));
        assert.isUndefined(lookupChar('test', 1.2));
    });
    it('Should return error when the index is too big', () => {
        let result = lookupChar('test', 100);

        assert.equal(result, 'Incorrect index');
    });
    it('Should return error when the index is the length', () => {
        let result = lookupChar('test', 4);

        assert.equal(result, 'Incorrect index');
    });
    it('Should return error when the index is negative', () => {
        let result = lookupChar('test', -1);

        assert.equal(result, 'Incorrect index');
    });
    it('Should return correct result when the input parameters are correct', () => {
        let string = 'Test';
        let index = 2;

        let result = lookupChar(string, index);

        assert.equal(result, string[index]);
    });
});