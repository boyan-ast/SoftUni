const pizzUni = require('../pizzUni');
const { assert } = require('chai');

describe('pizzUni test', () => {
    describe('makeAnOrder tests', () => {
        it('should throw exception when there is no pizza oreder', () => {
            let obj = {
                orderedDrink: 'Fanta'
            };

            assert.throw(() => pizzUni.makeAnOrder(obj), 'You must order at least 1 Pizza to finish the order.');
        });
        it('should throw exception when pizza is null', () => {
            let obj = {
                orderedPizza: null,
                orderedDrink: 'Fanta'
            };

            assert.throw(() => pizzUni.makeAnOrder(obj), 'You must order at least 1 Pizza to finish the order.');
        });
        it('should return correct result when only pizza ordered', () => {
            let obj = {
                orderedPizza: 'Testiana'
            };

            let expected = `You just ordered ${obj.orderedPizza}`;
            let actual = pizzUni.makeAnOrder(obj);

            assert.equal(actual, expected);
        });
        it('should return correct result when pizza and drink ordered', () => {
            let obj = {
                orderedPizza: 'Testiana',
                orderedDrink: 'Bira'
            };

            let expected = `You just ordered ${obj.orderedPizza} and Bira.`;
            let actual = pizzUni.makeAnOrder(obj);

            assert.equal(actual, expected);
        });
    });
    describe('getRemainingWork tests', () => {
        it('should return correct result when 2 of 3 pizzas are preapring', () => {
            let inputArr = [
                { pizzaName: 'Test1', status: 'preparing' },
                { pizzaName: 'Test2', status: 'preparing' },
                { pizzaName: 'Test3', status: 'ready' }];

            let expected = 'The following pizzas are still preparing: Test1, Test2.'; 
            let actual = pizzUni.getRemainingWork(inputArr);

            assert.equal(actual, expected);
        });
        it('should return correct result when 3 of 3 pizzas are preapring', () => {
            let inputArr = [
                { pizzaName: 'Test1', status: 'preparing' },
                { pizzaName: 'Test2', status: 'preparing' },
                { pizzaName: 'Test3', status: 'preparing' }];

            let expected = 'The following pizzas are still preparing: Test1, Test2, Test3.'; 
            let actual = pizzUni.getRemainingWork(inputArr);

            assert.equal(actual, expected);
        });
        it('should return correct result when 3 of 3 pizzas are ready', () => {
            let inputArr = [
                { pizzaName: 'Test1', status: 'ready' },
                { pizzaName: 'Test2', status: 'ready' },
                { pizzaName: 'Test3', status: 'ready' }];

            let expected = 'All orders are complete!'; 
            let actual = pizzUni.getRemainingWork(inputArr);

            assert.equal(actual, expected);
        });
    });
    describe('orderType tests', () => {
        it('should return correct sum when there is discount', () => {
            let totalSum = 150;

            let expected = totalSum * 0.9;

            assert.equal(pizzUni.orderType(totalSum, 'Carry Out'), expected);
        });
        it('should return correct sum when there is no discount', () => {
            let totalSum = 150;

            assert.equal(pizzUni.orderType(totalSum, 'Delivery'), totalSum);
        });
    });
});



