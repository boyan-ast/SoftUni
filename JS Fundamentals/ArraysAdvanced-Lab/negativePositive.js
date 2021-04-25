function solve(numbers) {
    let resultNumbers = [];

    for(let i = 0; i < numbers.length; i++) {
        if(numbers[i] < 0) {
            resultNumbers.unshift(numbers[i]);
        } else {
            resultNumbers.push(numbers[i]);
        }
    }

    console.log(resultNumbers.join("\n"));
}

solve([7, -2, 8, 9]);