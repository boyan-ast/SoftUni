const createCalculator = require('../07.calculator');
const { assert } = require('chai');

describe('Chech calculator functionality', () => {
    it('Function should return object', () => {
        assert.isObject(createCalculator());
    });
    it('Object should have method add', () => {
        let calc = createCalculator();

        let addType = typeof calc.add;

        assert.equal(addType, 'function');
    });
    it('Object should have method subtract', () => {
        let calc = createCalculator();

        let subtractType = typeof calc.subtract;

        assert.equal(subtractType, 'function');
    });
    it('Object should have method get', () => {
        let calc = createCalculator();

        let getType = typeof calc.get;

        assert.equal(getType, 'function');
    });
    it('Get should return 0 as initial value', () => {
        let expectedValue = 0;

        let calc = createCalculator();
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Add should add value correctly', () => {
        let addValue = 5;
        let expectedValue = 5;

        let calc = createCalculator();
        calc.add(addValue);
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Subtract should Subtract value correctly', () => {
        let subtractValue = 5;
        let expectedValue = -5;

        let calc = createCalculator();
        calc.subtract(subtractValue);
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Adding and then subtracting should work correctly', () => {
        let addValue = 10;
        let subtractValue = 5;
        let expectedValue = 5;

        let calc = createCalculator();
        calc.add(addValue);
        calc.subtract(subtractValue);
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Should work when number as string is provided to add function', () => {
        let addValue = '5';
        let addSecondValue = '15';
        let expectedValue = 20;

        let calc = createCalculator();
        calc.add(addValue);
        calc.add(addSecondValue);
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Should work when number as string is provided to subtract function', () => {
        let subtractValue = '5';
        let subtractSecondValue = '5';
        let expectedValue = -10;

        let calc = createCalculator();
        calc.subtract(subtractValue);
        calc.subtract(subtractSecondValue);
        let actualValue = calc.get();

        assert.equal(actualValue, expectedValue);
    });
    it('Sum cannot be modified from outside', () => {
        let calc = createCalculator();

        assert.isUndefined(calc.value);
    });
    it('Should not subtract when not a number is given', () => {
        let subtractValue = 'sto';

        let calc = createCalculator();
        calc.subtract(subtractValue);
        let actualValue = calc.get();

        assert.isNaN(actualValue);
    });
    it('Should not add when not a number is given', () => {
        let addValue = 'dvesta';

        let calc = createCalculator();
        calc.add(addValue);
        let actualValue = calc.get();

        assert.isNaN(actualValue);
    });
    it('Should work when adding and subtracting numbers as integer and string', () => {
        let addNum = '10.12';
        let subtractNum = 12.5;
        let addSecond = 15.4;
        let subtractSecond = '3';

        let expected = 10.12 - 12.5 + 15.4 - 3;

        let calc = createCalculator();
        calc.add(addNum);
        calc.subtract(subtractNum);
        calc.add(addSecond);
        calc.subtract(subtractSecond);
        let actual = calc.get();

        assert.equal(actual, expected);
    });
});