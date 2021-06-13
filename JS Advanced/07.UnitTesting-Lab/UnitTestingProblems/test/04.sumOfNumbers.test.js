const sum = require('../04.sumOfNumbers');
const { assert } = require('chai');

describe('Test Sum functionality', () => {
    it('Should take array of numbers as argument', () => {
        let input = [1, 2, 3, 4 ,5];
        let expected = 15;

        let actualResult = sum(input);

        assert.equal(actualResult, expected);
    });

    it('Shoud return correct result when numbers are negative', () => {
        let input = [-1, -2, -3]
        let expected = -6;

        let actual = sum(input);

        assert.equal(actual, expected);
    });

    it('Shoud return zero empty array is provided', () => {
        let input = []
        let expected = 0;

        let actual = sum(input);

        assert.equal(actual, expected);
    });
});