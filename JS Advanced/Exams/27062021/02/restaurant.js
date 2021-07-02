class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(productsArr) {
        for (const productInfo of productsArr) {
            let [name, quantity, totalPrice] = productInfo.split(' ');
            quantity = Number(quantity);
            totalPrice = Number(totalPrice);

            let action = '';

            if (totalPrice <= this.budgetMoney) {
                this.budgetMoney -= totalPrice;

                if (!this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += quantity;
                action = `Successfully loaded ${quantity} ${name}`;
            }
            else {
                action = `There was not enough money to load ${quantity} ${name}`;
            }

            this.history.push(action);
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {
                products: [],
                price: price
            }

            for (const productInfo of neededProducts) {
                let productInfoArr = productInfo.split(' ');
                let productName = '';
                let productQuantity = 0;

                if (productInfoArr.length == 2) {
                    productName = productInfoArr[0];
                    productQuantity = Number(productInfoArr[1]);
                }
                else if (productInfoArr.length > 2) {
                    productQuantity = Number(productInfoArr.pop());
                    productName = productInfoArr.join(' ');
                }

                this.menu[meal].products.push({ name: productName, quantity: productQuantity });
            }

            //console.log(this.menu);

            if (Object.keys(this.menu).length == 1) {
                let firstMealName = Object.keys(this.menu)[0];
                return `Great idea! Now with the ${firstMealName} we have 1 meal in the menu, other ideas?`;
            } else {
                return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
            }
        }
        else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length == 0) {
            return 'Our menu is not ready yet, please come later...';
        }
        else {
            let result = [];
            for (const key in this.menu) {
                result.push(`${key} - $ ${this.menu[key].price}`);
            }

            return result.join('\n');
        }
    }

    makeTheOrder(meal) {
        let menuMeal = this.menu[meal];

        if (menuMeal == undefined) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = menuMeal.products;

        let haveEverything = true;

        for (const prod of neededProducts) {
            if (!this.stockProducts.hasOwnProperty(prod.name)) {
                haveEverything = false;
                break;
            } else {
                if (this.stockProducts[prod.name] < prod.quantity) {
                    haveEverything = false;
                    break;
                }
            }
        }

        if (haveEverything) {
            for (const prod of neededProducts) {
                this.stockProducts[prod.name] -= prod.quantity;
            }
            let mealPrice = this.menu[meal].price;
            this.budgetMoney += mealPrice;

            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${mealPrice}.`;
        } else {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }
    }
}


let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));


let kitchen2 = new Restaurant(1000);
console.log(kitchen2.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen2.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen2.showTheMenu());

let kitchen3 = new Restaurant(1000);
kitchen3.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1', 'new 2']);
kitchen3.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 20'], 9.99);
console.log(kitchen3.makeTheOrder('frozenYogurt'));
