function simpleCalculator(firstNum, secondNum, operator) {
    let operation = defineOperation(operator);
    let result = operation(firstNum, secondNum);
    console.log(result);

    function defineOperation(operator) {
        let operation;
        if (operator == 'multiply') {
            operation = (a, b) => a * b;
        } else if (operator == 'divide') {
            operation = (a, b) => a / b;
        } else if (operator == 'add') {
            operation = (a, b) => a + b;
        } else if (operator == 'subtract') {
            operation = (a, b) => a - b;
        }

        return operation;
    }
}

simpleCalculator(5, 5, 'multiply');
simpleCalculator(40, 8, 'divide');
