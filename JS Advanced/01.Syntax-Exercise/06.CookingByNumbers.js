function solve(...operations) {
    let result = Number(operations.shift());
    let values = [];

    while (operations.length > 0) {
        let command = operations.shift();
        result = performOperation(command, result);
        values.push(result);
    }

    function performOperation(command, number) {
        let result = 0;

        if (command == 'chop') {
            result = number / 2;
        } else if (command == 'dice') {
            result = Math.sqrt(number);
        } else if (command == 'spice') {
            result = number + 1;
        } else if (command == 'bake') {
            result = number * 3;
        } else if (command == 'fillet') {
            result = number * 0.8;
        }

        return result;
    }

    return values.join('\n');
}

console.log(solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));