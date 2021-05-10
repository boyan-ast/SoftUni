function mathOperations(firstNum, secondNum, sign) {
    let result = 0;

    switch (sign) {
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
        case '%':
            result = firstNum % secondNum;
            break;
        case '**':
            result = firstNum ** secondNum;
            break;
        default:
            break;
    }

    console.log(result);
}

mathOperations(5, 6, '+');