function solve(input) {
    const matrix = [];

    for (let row = 0; row < input.length; row++) {
        matrix[row] = input[row].split(' ').map(Number);
    }

    let mainSum = 0;
    let secondarySum = 0;

    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix.length - 1 - row];
    }

    if (mainSum == secondarySum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row == col || (row + col == matrix.length - 1)) {
                    continue;
                } else {
                    matrix[row][col] = mainSum;
                }
            }
        }
    }

    matrix.forEach(r => console.log(r.join(' ')));
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(['1 1 1',
    '1 1 1',
    '1 1 0']);