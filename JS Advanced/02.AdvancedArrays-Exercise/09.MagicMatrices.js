function solve(matrix) {
    let magicSum = matrix[0].reduce((acc, val) => acc + val, 0);
    let isMagical = true;

    for (let row = 1; row < matrix.length; row++) {
        let sum = matrix[row].reduce((acc, val) => acc + val, 0);

        if (sum != magicSum) {
            isMagical = false;
            break;
        }
    }

    if (isMagical) {
        for (let col = 0; col < matrix[0].length; col++) {
            let sum = 0;
            for (let row = 0; row < matrix.length; row++) {
                sum += matrix[row][col];
            }
            if (sum != magicSum) {
                isMagical = false;
                break;
            }
        }
    }

    return isMagical;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));
console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
));