function diagonalSums(matrix) {
    let mainDiagonalSum = 0;
    let secDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row == col) {
                mainDiagonalSum += matrix[row][col];
            }

            if (row + col == matrix.length - 1) {
                secDiagonalSum += matrix[row][col];
            }
        }
    }

    console.log(mainDiagonalSum, secDiagonalSum);
}

diagonalSums([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
);