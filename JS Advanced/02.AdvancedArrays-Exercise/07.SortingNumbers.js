function sortingNumbers(input) {
    const sorted = input.sort((a, b) => a - b);
    const result = [];
    const n = sorted.length;

    for (let i = 0; i < n; i++){
        if (i % 2 == 0) {
            result.push(sorted.shift());
        } else {
            result.push(sorted.pop());
        }
    }

    return result;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));