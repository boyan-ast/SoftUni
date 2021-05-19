function lowestPriceInCities(input) {
    let products = {};

    for (let line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (products[product] == undefined ||
            price < products[product].price) {
            products[product] = { price, town };
        }
    }
    
    let result = '';

    for (let product of Object.keys(products)) {
        result += `${product} -> ${products[product].price} (${products[product].town})\n`;
    }

    return result;
}

console.log(lowestPriceInCities([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
));