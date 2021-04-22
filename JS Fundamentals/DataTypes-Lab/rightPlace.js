function rightPlace(input, char, expected) {
    let result = input.replace('_', char);

    if(result === expected) {
        return 'Matched';
    } else {
        return 'Not Matched';
    }
}

console.log(rightPlace('Str_ng', 'i', 'String'));

