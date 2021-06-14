const isOddOrEven = require('../02.EvenOrOdd');
const { assert } = require('chai');

describe('Test Even Or Odd', () => {
    it('Should return undefined if non string value is provided', () => {
        assert.isUndefined(isOddOrEven(1));
        assert.isUndefined(isOddOrEven({}));
        assert.isUndefined(isOddOrEven(true));
        assert.isUndefined(isOddOrEven([]));
        assert.isUndefined(isOddOrEven(null));
    });
    it('Should retun even when the input length is even number', () => {
        let input = 'even';

        result = isOddOrEven(input);

        assert.equal(result, 'even');
    });
    it('Should retun odd when the input length is odd number', () => {
        let input = 'odd';

        result = isOddOrEven(input);

        assert.equal(result, 'odd');
    });
});