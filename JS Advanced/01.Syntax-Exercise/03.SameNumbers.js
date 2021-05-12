function solve(number) {
    let numToString = number.toString();
    let sum = 0;
    let areSame = true;

    for (let i = 0; i <numToString.length - 1; i++) {
        if (numToString[i] !== numToString[i+1] && areSame) {
            areSame = false;
        }

        sum += Number(numToString[i]);
    }

    sum += number % 10;

    return areSame + '\n' + sum;
}

console.log(solve(2222222));