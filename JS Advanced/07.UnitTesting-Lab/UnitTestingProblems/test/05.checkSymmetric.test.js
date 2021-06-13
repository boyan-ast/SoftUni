const isSymmetric = require('../05.checkSymmetric');
const { assert } = require('chai');

describe ('Test Check for Symmetry function', () => {
    it('Should return false if the input is not an array', () => {
        let inputOne = 1;
        let inputTwo = undefined;
        let inputThree = 'string';
        let inputFour = {name: 'Test'};

        let resultOne = isSymmetric(inputOne);
        let resultTwo = isSymmetric(inputTwo);
        let resultThree = isSymmetric(inputThree);
        let resultFour = isSymmetric(inputFour);

        assert.isFalse(resultOne);
        assert.isFalse(resultTwo);
        assert.isFalse(resultThree);
        assert.isFalse(resultFour);        
    });
    it('Should return true if a symmetric numeric array is given', () => {
        let input = [1, 2, 3, 2, 1];

        assert.isTrue(isSymmetric(input));
    });
    it('Should return true if a symmetric string array is given', () => {
        let input = ['1', '2', '3', '2', '1'];

        assert.isTrue(isSymmetric(input));
    });
    it('Should return false if a nonsymmetric string array is given', () => {
        let input = ['1', '2', '3', '3', '1'];

        assert.isFalse(isSymmetric(input));
    });
    it('Should return false if the elements are different types', () => {
        let input = [1, '2', '3', 2, '1'];

        assert.isFalse(isSymmetric(input));
    });
});