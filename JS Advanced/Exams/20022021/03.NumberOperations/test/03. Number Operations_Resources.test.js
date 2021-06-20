const numberOperations = require('../03. Number Operations_Resources');
const { assert } = require('chai');

describe('numberOperation tests', () => {
    describe('powNumber tests', () => {
        it('should return correct result when number is positive', () => {
            let input = 3;

            let expected = 9;

            assert.equal(numberOperations.powNumber(input), expected);
        });
        it('should return correct result when number is negative', () => {
            let input = -4;

            let expected = 16;

            assert.equal(numberOperations.powNumber(input), expected);
        });

        it('should return correct result when number is floating number', () => {
            let input = 5.5;

            let expected = 5.5 * 5.5;

            assert.equal(numberOperations.powNumber(input), expected);
        });
    });
    describe('numberChecker tests', () => {
        it('should throw error when the input is not a number', () => {
            assert.throw(() => numberOperations.numberChecker('str'));
            assert.throw(() => numberOperations.numberChecker(undefined));          
            assert.throw(() => numberOperations.numberChecker(NaN));          
        });
        it('should return correct result when number is less than 100', () => {
            let expected = 'The number is lower than 100!';

            assert.equal(numberOperations.numberChecker(10), expected);
            assert.equal(numberOperations.numberChecker(-10), expected);
            assert.equal(numberOperations.numberChecker(0), expected);
        });
        it('should return correct result when number is greater than 100', () => {
            let expected = 'The number is greater or equal to 100!';

            assert.equal(numberOperations.numberChecker(101), expected);
            assert.equal(numberOperations.numberChecker(200), expected);
            assert.equal(numberOperations.numberChecker(1000.53), expected);
        });
        it('should return correct result when number is equal to 100', () => {
            let expected = 'The number is greater or equal to 100!';

            assert.equal(numberOperations.numberChecker(100), expected);
        });
    });
    describe('sumArrays tests', () => {
        it('should return correct array when the two array have equal length', () => {
            let firstArray = [1, 1.2, -1234];
            let secondArray = [2, 23.3, 300];

            let expected = [firstArray[0] + secondArray[0], firstArray[1] + secondArray[1], firstArray[2] + secondArray[2]];

            assert.deepEqual(numberOperations.sumArrays(firstArray, secondArray), expected);
        });
        it('should return correct array when the first array has more elements', () => {
            let firstArray = [1, 1.2, -1234, 551, 13, 1];
            let secondArray = [2, 23.3, 300];

            let expected = [firstArray[0] + secondArray[0], 
                    firstArray[1] + secondArray[1], 
                    firstArray[2] + secondArray[2],
                    firstArray[3],
                    firstArray[4],
                    firstArray[5]];

            assert.deepEqual(numberOperations.sumArrays(firstArray, secondArray), expected);
        });
        it('should return correct array when the first array has less elements', () => {
            let firstArray = [2, 23.3, 300];
            let secondArray = [1, 1.2, -1234, 551, 13, 1];

            let expected = [firstArray[0] + secondArray[0], 
                    firstArray[1] + secondArray[1], 
                    firstArray[2] + secondArray[2],
                    secondArray[3],
                    secondArray[4],
                    secondArray[5]];

            assert.deepEqual(numberOperations.sumArrays(firstArray, secondArray), expected);
        });
    });
});