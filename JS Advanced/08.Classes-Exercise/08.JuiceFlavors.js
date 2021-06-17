function solve(input) {
    let juiceBottles = new Map();
    let fruits = new Map();

    for (let juice of input) {
        let [fruit, quantity] = juice.split(' => ');
        quantity = Number(quantity);

        if (!fruits.has(fruit)) {
            fruits.set(fruit, 0);
        }

        let fruitCurrentQuantity = fruits.get(fruit);
        fruits.set(fruit, fruitCurrentQuantity + quantity);

        let totalFruitQuantity = fruits.get(fruit);

        if (totalFruitQuantity >= 1000) {            
            if (!juiceBottles.has(fruit)) {
                juiceBottles.set(fruit, 0);
            }

            let currentBottles = juiceBottles.get(fruit);

            let newBottles = Math.floor(totalFruitQuantity / 1000);
            totalFruitQuantity -= newBottles * 1000;
            fruits.set(fruit, totalFruitQuantity);
            juiceBottles.set(fruit, currentBottles + newBottles);
        }
    }

    let output = [];

    for (const [key, value] of juiceBottles) {
        output.push(`${key} => ${value}`);
    }

    return output.join('\n');
}

console.log(solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
));

console.log(solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
));