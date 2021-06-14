const mathEnforcer = require('../04.MathEnforcer');
const { assert } = require('chai');

describe('mathEnforcer', () => {
    describe('addFive function', () => {
        it('Should return undefined with non-number parameter', () => {
            assert.isUndefined(mathEnforcer.addFive('string'));
            assert.isUndefined(mathEnforcer.addFive(null));
            assert.isUndefined(mathEnforcer.addFive(undefined));
            assert.isUndefined(mathEnforcer.addFive([]));
        });
        it('Should work correctly with positive integer input', () => {
            let input = 95;
            let expected = 100;

            let result = mathEnforcer.addFive(input);

            assert.equal(result, expected);
        });
        it('Should work correctly with negative integer input', () => {
            let input = -95;
            let expected = -90;

            let result = mathEnforcer.addFive(input);

            assert.equal(result, expected);
        });
        it('Should work correctly with positive float number input', () => {
            let input = 1.1000000001;
            let expected = 6.1;

            let result = mathEnforcer.addFive(input);

            assert.closeTo(result, expected, 0.01);
        });
    });
    describe('subtractTen function', () => {
        it('Should return undefined with non-number parameter', () => {
            assert.isUndefined(mathEnforcer.subtractTen('string'));
            assert.isUndefined(mathEnforcer.subtractTen(null));
            assert.isUndefined(mathEnforcer.subtractTen(undefined));
            assert.isUndefined(mathEnforcer.subtractTen([]));
        });
        it('Should work correctly with positive integer input', () => {
            let input = 95;
            let expected = 85;

            let result = mathEnforcer.subtractTen(input);

            assert.equal(result, expected);
        });
        it('Should work correctly with negative integer input', () => {
            let input = -95;
            let expected = -105;

            let result = mathEnforcer.subtractTen(input);

            assert.equal(result, expected);
        });
        it('Should work correctly with positive float number input', () => {
            let input = 1.100000005;
            let expected = -8.9;

            let result = mathEnforcer.subtractTen(input);

            assert.closeTo(result, expected, 0.01);
        });
    });
    describe('sum function', () => {
        it('Should return undefined with non-number first parameter', () => {
            assert.isUndefined(mathEnforcer.sum('string', 10));
            assert.isUndefined(mathEnforcer.sum(null, 10));
            assert.isUndefined(mathEnforcer.sum(undefined, 10));
            assert.isUndefined(mathEnforcer.sum([], 10));
        });
        it('Should return undefined with non-number second parameter', () => {
            assert.isUndefined(mathEnforcer.sum(10, 'string'));
            assert.isUndefined(mathEnforcer.sum(10, null));
            assert.isUndefined(mathEnforcer.sum(10, undefined));
            assert.isUndefined(mathEnforcer.sum(10, []));
        });
        it('Should work correctly with positive integer first param and negative integer second param', () => {
            let first = 95;
            let second = -22;
            let expected = first + second;

            let result = mathEnforcer.sum(first, second);

            assert.equal(result, expected);
        });
        it('Should work correctly with negative input parameters', () => {
            let first = -95;
            let second = -22;
            let expected = first + second;

            let result = mathEnforcer.sum(first, second);

            assert.equal(result, expected);
        });
        it('Should work correctly with positive floating numbers as input', () => {
            let first = 95.00000008;
            let second = -22.0100002;
            let expected = first + second;

            let result = mathEnforcer.sum(first, second);

            assert.equal(result, expected);
        });
    });
});