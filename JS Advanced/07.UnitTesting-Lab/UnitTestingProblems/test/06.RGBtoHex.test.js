const rgbToHexColor = require('../06.RGBtoHex');
const { assert } = require('chai');

describe('Check RGB to Hex functionality', () => {
    it('Should return undefined when a non integer value is given for red', () => {
        let redValue = 15.23;

        assert.equal(rgbToHexColor(redValue, 100, 200), undefined);
    });
    it('Should return undefined when a negative value is given for red', () => {
        let redValue = -100;

        assert.equal(rgbToHexColor(redValue, 100, 200), undefined);
    });
    it('Should return undefined when a very big value is given for red', () => {
        let redValue = 278;

        assert.equal(rgbToHexColor(redValue, 100, 200), undefined);
    });
    it('Should return undefined when an invalid value is given for green', () => {
        assert.isUndefined(rgbToHexColor(100, 'green', 200));
        assert.isUndefined(rgbToHexColor(100, -1, 200));
        assert.isUndefined(rgbToHexColor(100, 1000, 200));
    });    
    it('Should return undefined when an invalid value is given for blue', () => {
        assert.isUndefined(rgbToHexColor(100, 200, '200.12'));
        assert.isUndefined(rgbToHexColor(100, 200, -200));
        assert.isUndefined(rgbToHexColor(100, 200, 1200));
    });
    it('Should return correct result with correct input values', () => {
        let inputRed = 123;
        let inputGreen = 234;
        let inputBlue = 245;
        let expectedResult = '#7BEAF5';

        let actualResult = rgbToHexColor(inputRed, inputGreen, inputBlue);

        assert.equal(actualResult, expectedResult);
    });
    it('Should return correct result with zero input values', () => {
        let inputRed = 0;
        let inputGreen = 0;
        let inputBlue = 0;
        let expectedResult = '#000000';

        let actualResult = rgbToHexColor(inputRed, inputGreen, inputBlue);

        assert.equal(actualResult, expectedResult);
    });
    it('Should return correct result with max input values', () => {
        let inputRed = 255;
        let inputGreen = 255;
        let inputBlue = 255;
        let expectedResult = '#FFFFFF';

        let actualResult = rgbToHexColor(inputRed, inputGreen, inputBlue);

        assert.equal(actualResult, expectedResult);
    });
});