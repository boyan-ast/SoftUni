function equalNeighbors(matrix) {
    let count = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (isValid(row -1, col, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row - 1][col]) {
                count++;
            }
            if (isValid(row, col, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row][col - 1]) {
                count++;
            }
            if (isValid(row, col + 1, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row][col + 1]) {
                count++
            }
            if (isValid(row + 1, col, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row + 1][col]) {
                count++;
            }
        }
    }

    return count / 2;

    function isValid(row, col, n, m) {
        if (row < 0 || row >= n || col < 0 || col >= m) {
            return false;
        }

        return true;
    }
}

console.log(equalNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));