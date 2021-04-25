function solve(commands) {
    let array = commands
        .shift()
        .split(' ')
        .map(Number);

    for (let i = 0; i < commands.length; i++) {
        let [command, firstNum, secondNum] = commands[i].split(' ');

        firstNum = Number(firstNum);
        secondNum = Number(secondNum);

        if (command == 'Add') {
            array.push(firstNum);
        } else if (command == 'Remove') {
            array = array.filter(x => x !== firstNum);
        } else if (command == 'RemoveAt') {
            array.splice(firstNum, 1);
        } else if (command == 'Insert') {
            array.splice(secondNum, 0, firstNum);
        }
    }

    console.log(array.join(' '));
}

solve(['4 19 2 53 6 43',
'Add 3',
'Remove 2',
'RemoveAt 1',
'Insert 8 3']
);