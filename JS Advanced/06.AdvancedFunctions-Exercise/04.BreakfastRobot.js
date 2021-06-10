function solution() {
    let products = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    return function (input) {
        let [command, ...args] = input.split(' ');

        if (command == 'restock') {
            let element = args[0];
            let quantity = Number(args[1]);

            products[element] += quantity;
            return 'Success';
        } else if (command == 'prepare') {
            let product = args[0];
            let quantity = Number(args[1]);

            if (product == 'apple') {
                return prepareApple(quantity);
            } else if (product == 'lemonade') {
                return prepareLemonade(quantity);
            } else if (product == 'burger') {
                return prepareBurger(quantity);
            } else if (product == 'eggs') {
                return prepareEggs(quantity);
            } else if (product == 'turkey') {
                return prepareTurkey(quantity);
            }
        } else if (command == 'report') {
            let result = '';

            for (let product in products) {
                result += `${product}=${products[product]} `;
            }

            return result.trim();
        }
    }

    function prepareApple(quantity) {
        let neededCarbohydrate = quantity * 1;
        let neededFlavour = quantity * 2;

        if (neededCarbohydrate > products.carbohydrate) {
            return errorMessage('carbohydrate');
        } else if (neededFlavour > products.flavour) {
            return errorMessage('flavour');
        } else {
            products.carbohydrate -= neededCarbohydrate;
            products.flavour -= neededFlavour;
            return 'Success';
        }
    }

    function prepareLemonade(quantity) {
        let neededCarbohydrate = quantity * 10;
        let neededFlavour = quantity * 20;

        if (neededCarbohydrate > products.carbohydrate) {
            return errorMessage('carbohydrate');
        } else if (neededFlavour > products.flavour) {
            return errorMessage('flavour');
        } else {
            products.carbohydrate -= neededCarbohydrate;
            products.flavour -= neededFlavour;
            return 'Success';
        }
    }

    function prepareBurger(quantity) {
        let neededCarbohydrate = quantity * 5;
        let neededFat = quantity * 7;
        let neededFlavour = quantity * 3;

        if (neededCarbohydrate > products.carbohydrate) {
            return errorMessage('carbohydrate');
        } else if (neededFat > products.fat) {
            return errorMessage('fat');
        } else if (neededFlavour > products.flavour) {
            return errorMessage('flavour');
        } else {
            products.carbohydrate -= neededCarbohydrate;
            products.fat -= neededFat;
            products.flavour -= neededFlavour;
            return 'Success';
        }
    }

    function prepareEggs(quantity) {
        let neededProtein = quantity * 5;
        let neededFat = quantity * 1;
        let neededFlavour = quantity * 1;

        if (neededProtein > products.protein) {
            return errorMessage('protein');
        } else if (neededFat > products.fat) {
            return errorMessage('fat');
        } else if (neededFlavour > products.flavour) {
            return errorMessage('flavour');
        } else {
            products.protein -= neededProtein;
            products.fat -= neededFat;
            products.flavour -= neededFlavour;
            return 'Success';
        }
    }

    function prepareTurkey(quantity) {
        let neededProtein = quantity * 10;
        let neededCarbohydrate = quantity * 10;
        let neededFat = quantity * 10;
        let neededFlavour = quantity * 10;

        if (neededProtein > products.protein) {
            return errorMessage('protein');
        } else if (neededCarbohydrate > products.carbohydrate) {
            return errorMessage('carbohydrate');
        } else if (neededFat > products.fat) {
            return errorMessage('fat');
        } else if (neededFlavour > products.flavour) {
            return errorMessage('flavour');
        } else {
            products.protein -= neededProtein;
            products.carbohydrate -= neededCarbohydrate;
            products.fat -= neededFat;
            products.flavour -= neededFlavour;
            return 'Success';
        }
    }

    function errorMessage(item) {
        return `Error: not enough ${item} in stock`;
    }
}



let manager = solution();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare apple 4")); // Error: not enough carbohydrate in stock
console.log(manager("prepare lemonade 4"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));
