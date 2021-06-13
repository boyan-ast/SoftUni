function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

module.exports = createCalculator;

let calc = createCalculator();
calc.add(5);
console.log(calc.get());
calc.add(5);
console.log(calc.get());
calc.subtract('sto');
console.log(calc.get());
console.log(createCalculator().add());