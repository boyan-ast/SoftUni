function solve(numbers) {
    let length = numbers.length;

    let resultArray = [];

    while (length > 1) {
        for (let i = 0; i < length - 1; i++) {
            resultArray.push(numbers[i] + numbers[i + 1]);
        }

        numbers = resultArray;
        resultArray = [];
        length = numbers.length;
    }

    console.log(numbers[0]);
}

solve([1]);