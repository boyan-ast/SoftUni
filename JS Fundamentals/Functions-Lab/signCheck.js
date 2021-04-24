function signCheck(numOne, numTwo, numThree) {
    let numbers = [numOne, numTwo, numThree];
    let negativesCount = numbers.filter(n => n < 0).length;
    if (negativesCount % 2 == 1) {
        return 'Negative';
    } else {
        return 'Positive';
    }
}

console.log(signCheck(-1, 2, 3));
console.log(signCheck(1, 2, 3));
console.log(signCheck(-1, -2, 3));