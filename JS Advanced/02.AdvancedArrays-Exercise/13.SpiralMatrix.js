function solve(rows, cols) {

    const matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = 0;
        }
    }

    let row = 0;
    let col = 0;

    let direction = 'right';

    for (let num = 1; num <= rows * cols; num++) {
        matrix[row][col] = num;

        if (direction == 'right') {
            col++;

            if (col == matrix[row].length || matrix[row][col] != 0) {
                col--;
                row++;
                direction = 'down';
            }
        } else if (direction == 'down') {
            row++;

            if (row == matrix.length || matrix[row][col] != 0) {
                row--;
                col--;
                direction = 'left';
            }
        } else if (direction == 'left') {
            col--;

            if (col == -1 || matrix[row][col] != 0) {
                col++;
                row--;
                direction = 'up';
            }
        } else if (direction == 'up') {
            row--;

            if (row == -1 || matrix[row][col] != 0) {
                row++;
                col++;
                direction = 'right';
            }
        }
    }

    printMatrix(matrix);


    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '));
        }
    }
}

solve(5, 5);
solve(3, 3);