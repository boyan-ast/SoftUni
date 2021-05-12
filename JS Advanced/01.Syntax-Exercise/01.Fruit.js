function solve(type, weightInGrams, price) {
    const weight = weightInGrams / 1000;
    const totalPrice = weight * price;

    return `I need $${totalPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${type}.`;
}

console.log(solve('orange', 2500, 1.80));