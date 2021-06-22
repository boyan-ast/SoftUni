const dealership = require('../dealership');
const { assert } = require('chai');

describe('dealership tests', () => {
    describe('newCarCost tests', () => {
        it('should return correct price with discount when car is existing, first', () => {
            let oldCarModel = 'Audi A4 B8';
            let discount = 15000;
            let newCarPrice = 40000;

            let expectedFinalPrice = newCarPrice - discount;
            let actualFinalPrice = dealership.newCarCost(oldCarModel, newCarPrice);
            assert.equal(actualFinalPrice, expectedFinalPrice);
        });
        it('should return correct price with discount when car is existing, second', () => {
            let oldCarModel = 'Audi A6 4K';
            let discount = 20000;
            let newCarPrice = 40000;

            let expectedFinalPrice = newCarPrice - discount;
            let actualFinalPrice = dealership.newCarCost(oldCarModel, newCarPrice);
            assert.equal(actualFinalPrice, expectedFinalPrice);
        });
        it('should return correct price with discount when car is existing, third', () => {
            let oldCarModel = 'Audi A8 D5';
            let discount = 25000;
            let newCarPrice = 40000;

            let expectedFinalPrice = newCarPrice - discount;
            let actualFinalPrice = dealership.newCarCost(oldCarModel, newCarPrice);
            assert.equal(actualFinalPrice, expectedFinalPrice);
        });
        it('should return correct price with discount when car is existing, fourth', () => {
            let oldCarModel = 'Audi TT 8J';
            let discount = 14000;
            let newCarPrice = 40000;

            let expectedFinalPrice = newCarPrice - discount;
            let actualFinalPrice = dealership.newCarCost(oldCarModel, newCarPrice);
            assert.equal(actualFinalPrice, expectedFinalPrice);
        });
        it('should return correct price without discount', () => {
            let oldCarModel = 'Renault Megane';
            let newCarPrice = 40000;

            let actualFinalPrice = dealership.newCarCost(oldCarModel, newCarPrice);

            assert.equal(actualFinalPrice, newCarPrice)
        });
    });
    describe('carEquipment tests', () => {
        it('should return correct extras when the extrasArr is bigger than the indexArr', () => {
            let extrasArr = ['klimatik', 'shibidah', 'el. stykla', 'el. ogledala'];
            let indexArr = [1, 3];

            let expected = ['shibidah', 'el. ogledala'];
            let actual = dealership.carEquipment(extrasArr, indexArr);

            assert.deepEqual(actual, expected);

        });

        it('should return correct extras when the extrasArr length is equal to the indexArr length', () => {
            let extrasArr = ['klimatik', 'shibidah', 'el. stykla', 'el. ogledala'];
            let indexArr = [0, 1, 2, 3];

            let expected = ['klimatik', 'shibidah', 'el. stykla', 'el. ogledala'];
            let actual = dealership.carEquipment(extrasArr, indexArr);

            assert.deepEqual(actual, expected);

        });
    });
    describe('euroCategory tests', () => {
        it('should return discounted price when the category is 4', () => {
            assert.equal(dealership.euroCategory(4), `We have added 5% discount to the final price: ${14250}.`)
        });
        it('should return discounted price when the category is bigger than 4', () => {
            assert.equal(dealership.euroCategory(6), `We have added 5% discount to the final price: ${14250}.`)
        });
        it('should return correct message when the category is less than 4', () => {
            assert.equal(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
        });
    });
});