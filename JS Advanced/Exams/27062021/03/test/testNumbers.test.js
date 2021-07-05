const testNumbers = require('../testNumbers');
const { assert } = require('chai');

describe('test testNumber', () => {
    describe('test sumNumbers', () => {
        it('should return undefinded when num1 is not a number', () => {
            assert.isUndefined(testNumbers.sumNumbers('first', 100));
            assert.isUndefined(testNumbers.sumNumbers([], 100));
            assert.isUndefined(testNumbers.sumNumbers({}, 100));
        });
        it('should return undefinded when num2 is not a number', () => {
            assert.isUndefined(testNumbers.sumNumbers(100, 'sto'));
            assert.isUndefined(testNumbers.sumNumbers(200, []));
            assert.isUndefined(testNumbers.sumNumbers(300, {}));
        });
        it('should return undefinded when both are not numbers', () => {
            assert.isUndefined(testNumbers.sumNumbers('edno', 'sto'));
            assert.isUndefined(testNumbers.sumNumbers([], []));
            assert.isUndefined(testNumbers.sumNumbers({}, {}));
        });
        it('should work with positive integers', () => {
            let num1 = 123;
            let num2= 234;

            let expected = num1 + num2;

            assert.strictEqual(testNumbers.sumNumbers(num1, num2), expected.toFixed(2));
        });
        it('should work with negative integers', () => {
            let num1 = -123;
            let num2= -234;

            let expected = num1 + num2;

            assert.strictEqual(testNumbers.sumNumbers(num1, num2), expected.toFixed(2));
        });
        it('should work with negative floating nums', () => {
            let num1 = -123.123;
            let num2= -234.23123;

            let expected = num1 + num2;

            assert.strictEqual(testNumbers.sumNumbers(num1, num2), expected.toFixed(2));
        });
        it('should work with positive floating nums', () => {
            let num1 = 123.123;
            let num2= 234.23123;

            let expected = num1 + num2;

            assert.strictEqual(testNumbers.sumNumbers(num1, num2), expected.toFixed(2));
        });
    });
    describe('test numberChecker', () => {
        it('should throw if number is NaN', () => {
            assert.throw(() => testNumbers.numberChecker('str'), Error, 'The input is not a number!');
            assert.throw(() => testNumbers.numberChecker([1, 2]), Error, 'The input is not a number!');
            assert.throw(() => testNumbers.numberChecker({}), Error, 'The input is not a number!');
        });
        it('should work with positive and negative even', () => {
            assert.strictEqual(testNumbers.numberChecker(12), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(-120), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(0), 'The number is even!');
        });
        it('should work with positive and negative odd', () => {
            assert.strictEqual(testNumbers.numberChecker(13), 'The number is odd!');
            assert.strictEqual(testNumbers.numberChecker(-121), 'The number is odd!');
        });
    });
    describe('test averageSumArray', () => {
        it('should return NaN with empty array', () => {
            assert.isNaN(testNumbers.averageSumArray([]));
        });
        it('should work with postive number', () => {
            let input = [1, 23, 123.12, 17];

            let expected = input.reduce((a, el) => a + el/input.length, 0);

            assert.strictEqual(testNumbers.averageSumArray(input), expected);
        });
        it('should work with negative number', () => {
            let input = [-1, -23, -123.12, -17];

            let expected = input.reduce((a, el) => a + el/input.length, 0);

            assert.strictEqual(testNumbers.averageSumArray(input), expected);
        });
        it('should work with positive and negative number', () => {
            let input = [-1, -23, 123.12, 17];

            let expected = input.reduce((a, el) => a + el/input.length, 0);

            assert.strictEqual(testNumbers.averageSumArray(input), expected);
        });
    });
});