function solve(input) {
    const products = {};

    for (let line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (products[product] == undefined) {
            products[product] = {};
        }

        products[product][town] = price;
    }

    let result = [];

    for (let productInfo of Object.entries(products)) {
        let productName = productInfo[0];
        let ordered = Object.entries(productInfo[1]).sort((a,b) => a[1] - b[1]);
        let town = ordered[0][0];
        let price = ordered[0][1];

        result.push(`${productName} -> ${price} (${town})`);
    }

    return result.join('\n');
}

console.log(solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
));

console.log(solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000']
));