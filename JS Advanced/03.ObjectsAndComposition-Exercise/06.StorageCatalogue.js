function storageCatalogue(input) {
    let catalogue = [];

    for (let line of input) {
        let [product, price] = line.split(' : ');

        price = Number(price);

        catalogue.push({ product, price });
    }

    catalogue.sort((a, b) => {
        return a.product.localeCompare(b.product);
    })

    let result = {};

    for (let item of catalogue) {
        let firstLetter = item.product.charAt(0).toUpperCase();

        if (result[firstLetter] == undefined) {
            result[firstLetter] = [];
        }

        result[firstLetter].push({ name: item.product, price: item.price });
    }

    for (let letter in result) {
        console.log(letter);

        result[letter].forEach(element => {
            console.log(`${element.name}: ${element.price}`);
        });
    }
}

storageCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);