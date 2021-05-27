function solve(input) {
    const rows = input.shift();
    const cols = input.shift();
    const starRow = input[0];
    const starCol = input[1];

    const matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];        
    }

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
        }
    }

    printMatrix(matrix);
   

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '));
        }
    }

}

solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);