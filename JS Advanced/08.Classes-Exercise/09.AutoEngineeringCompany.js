function solve(input) {
    let brands = new Map();

    for (const carInfo of input) {
        let [brand, model, count] = carInfo.split(' | ');
        count = Number(count);

        if (!brands.has(brand)) {
            brands.set(brand, new Map());
        }

        let models = brands.get(brand);

        if (!models.has(model)) {
            models.set(model, 0);
        }

        let modelsCurrentCount = models.get(model);
        models.set(model, modelsCurrentCount + count);
    }

    let output = [];

    for (const [brand, modelsPair] of brands) {
        output.push(brand);

        for (const [model, count] of modelsPair) {
            output.push(`###${model} -> ${count}`);
        }
    }

    return output.join('\n');
}

console.log(solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
));