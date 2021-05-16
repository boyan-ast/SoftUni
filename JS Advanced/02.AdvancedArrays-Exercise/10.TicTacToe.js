function solve(moves) {
    const matrix = [];

    for (let row = 0; row < 3; row++) {
        matrix[row] = [];
        for (let col = 0; col < 3; col++) {
            matrix[row][col] = false;
        }
    }

    count = 0;
    let hasWinner = false;

    let isFirstPlayer = true;
    let isSecondPlayer = false;

    for (let i = 0; i < moves.length; i++) {

        let [playerRow, playerCol] = moves[i].split(' ').map(Number);

        if (matrix[playerRow][playerCol] == false) {
            if (isFirstPlayer) {
                matrix[playerRow][playerCol] = 'X';
                isFirstPlayer = false;
                isSecondPlayer = true;
                count++;

                if (isWinning(matrix, 'X')) {
                    console.log('Player X wins!');
                    hasWinner = true;
                    break;
                }
            } else if (isSecondPlayer) {
                matrix[playerRow][playerCol] = 'O';
                isFirstPlayer = true;
                isSecondPlayer = false;
                count++;

                if (isWinning(matrix, 'O')) {
                    console.log('Player O wins!');
                    hasWinner = true;
                    break;
                }
            }
        } else {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        if (hasWinner) {
            break;
        } else if (count == 9) {
            console.log('The game ended! Nobody wins :(');
            break;
        }
    }

    for (let row = 0; row < 3; row++) {
        console.log(matrix[row].join('\t'));
    }

    function isWinning(matrix, playerSign) {
        for (let row = 0; row < 3; row++) {
            if (matrix[row].every(c => c == playerSign)) {
                return true;
            }
        }

        for (let col = 0; col < 3; col++) {
            for (let row = 0; row < 3; row++) {
                if (matrix[row][col] != playerSign) {
                    break;
                } else if (row == 2) {
                    return true;
                }
            }
        }

        for (let row = 0; row < 3; row++) {
            if (matrix[row][row] != playerSign) {
                break;
            } else if (row == 2) {
                return true;
            }
        }

        for (let row = 0; row < 3; row++) {
            if (matrix[row][2 - row] != playerSign) {
                break;
            } else if (row == 2) {
                return true;
            }
        }

        return false;
    }
}

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);

solve(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);