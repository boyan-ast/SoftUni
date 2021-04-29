function solve(input) {
    let storage = new Map();

    for (let productInfo of input) {
        let [name, quantity] = productInfo.split(' ');

        if (!storage.has(name)) {
            storage.set(name, 0);
        }

        let currentQuantity = storage.get(name);
        currentQuantity += Number(quantity);
        storage.set(name, currentQuantity);
    }

    for (let kvp of storage) {
        console.log(`${kvp[0]} -> ${kvp[1]}`);
    }
}

solve(['tomatoes 10',
'coffee 5',
'olives 100',
'coffee 40']);