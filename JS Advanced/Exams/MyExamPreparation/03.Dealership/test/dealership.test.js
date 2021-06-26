const dealership = require('../dealership');
const { assert } = require('chai');

describe('test dealership', () => {
    describe('test newCarCost', () => {
        it('should discount', () => {
            let model1 = 'Audi A4 B8';
            let discount1 = 15000;

            let model2 = 'Audi A6 4K';
            let discount2 = 20000;

            let model3 = 'Audi A8 D5';
            let discount3 = 25000;

            let model4 = 'Audi TT 8J';
            let discount4 = 14000;

            let newPrice = 50000;

            let expected1 = newPrice - discount1;
            let expected2 = newPrice - discount2;
            let expected3 = newPrice - discount3;
            let expected4 = newPrice - discount4;

            assert.strictEqual(dealership.newCarCost(model1, newPrice), expected1);
            assert.strictEqual(dealership.newCarCost(model2, newPrice), expected2);
            assert.strictEqual(dealership.newCarCost(model3, newPrice), expected3);
            assert.strictEqual(dealership.newCarCost(model4, newPrice), expected4);
        });
        it('shouldn\'t discount', () => {
            let model = 'BMW';
            let newPrice = 30000;

            assert.strictEqual(dealership.newCarCost(model, newPrice), newPrice);
        });
    });
    describe('test carEquipment', () => {
        it('should work with one index', () => {
            let extras = ['klimatik', 'el. stykla', 'el. ogledala', 'pechka'];
            let indexes = [1];

            let expected = ['el. stykla'];

            assert.deepEqual(dealership.carEquipment(extras, indexes), expected);
        });
        it('should work with more indexes', () => {
            let extras = ['klimatik', 'el. stykla', 'el. ogledala', 'pechka'];
            let indexes = [0, 1, 2, 3];

            let expected = ['klimatik', 'el. stykla', 'el. ogledala', 'pechka'];

            assert.deepEqual(dealership.carEquipment(extras, indexes), expected);
        });
        it('should work with empty arrays', () => {
            let extras = [];
            let indexes = [];

            let expected = [];

            assert.deepEqual(dealership.carEquipment(extras, indexes), expected);
        });
    });
    describe('test euroCategory', () => {
        it('should work category 4', () => {
            let expectedPrice = 15000*0.95;
            let expected = `We have added 5% discount to the final price: ${expectedPrice}.`;

            assert.strictEqual(dealership.euroCategory(4), expected);
        });
        it('should work category 6', () => {
            let expectedPrice = 15000*0.95;
            let expected = `We have added 5% discount to the final price: ${expectedPrice}.`;

            assert.strictEqual(dealership.euroCategory(6), expected);
        });
        it('should work category 3', () => {
            let expected = `Your euro category is low, so there is no discount from the final price!`;

            assert.strictEqual(dealership.euroCategory(3), expected);
        });
    });
});