function solve(input) {
    let numbers = [];

    for (let i = 0; i < input.length; i++) {
        if (Number.isInteger(input[i])) {
            numbers.push(input[i]);
        } else {
            if (numbers.length > 1) {
                let second = numbers.pop();
                let first = numbers.pop();
                numbers.push(Math.ceil(calculate(input[i], first, second)));
            } else {
                return 'Error: not enough operands!';
            }
        }
    }

    if (numbers.length == 1) {
        return numbers[0];
    } else {
        return 'Error: too many operands!';
    }

    function calculate(operator, firstNum, secondNum) {
        let result = 0;
        switch (operator) {
            case '+':
                result = firstNum + secondNum;
                break;
            case '-':
                result = firstNum - secondNum;
                break;
            case '*':
                result = firstNum * secondNum;
                break;
            case '/':
                result = firstNum / secondNum;
                break;
            default:
                break;
        }

        return result;
    }
}

console.log(solve([-1, 1, '+', 101, '*', 18, '+', 3, '/']));

console.log(solve([
    15,
    '/']
));

console.log(solve([
    5,
    3,
    4,
    '*',
    '-']
));

console.log(solve([
    7,
    33,
    8,
    '-']
));

console.log(solve([
    3,
    4,
    '+']
));


