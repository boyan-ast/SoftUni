function calculate(product, quantity){

    let sum = quantity * productPrice(product);

    return sum.toFixed(2);

    function productPrice(product) {
        let price = 0;

        switch (product) {
            case 'coffee':
                price = 1.50;
                break;
            case 'water':
                price = 1.00;
                break;
            case 'coke':
                price = 1.40;
                break;
            case 'snacks':
                price = 2.00;
                break;
            default:
                break;
        }

        return price;
    }
}

console.log(calculate('coffee', 2));