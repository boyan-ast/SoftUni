function solve(firstArray, secondArray) {
    let maxLength = Math.max(firstArray.length, secondArray.length);

    for (let i = 0; i < maxLength; i++) {
        if (firstArray[i] !== secondArray[i]) {
            return `Arrays are not identical. Found difference at ${i} index`;
        }
    }

    let sum = firstArray.map(e => Number(e)).reduce((a, b) => a + b, 0);

    return `Arrays are identical. Sum: ${sum}`;
}

console.log(solve(['1','2','3','4','5'], ['1','2','4','4','5']));