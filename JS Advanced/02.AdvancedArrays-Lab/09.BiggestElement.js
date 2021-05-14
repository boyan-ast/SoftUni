function solve(matrix) {
    let maxElement = Number.NEGATIVE_INFINITY;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (maxElement < matrix[row][col]) {
                maxElement = matrix[row][col];
            }
        }
    }

    return maxElement;
}

console.log(solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
));


console.log(solve([[-123]]
));