function solve(elements) {
    const result = [];

    for(let number of elements) {
        if (number < 0) {
            result.unshift(number);
        } else {
            result.push(number);
        }
    }

    let print = result.join('\r\n')

    return print;
}

console.log(solve([7, -2, 8, 9]));