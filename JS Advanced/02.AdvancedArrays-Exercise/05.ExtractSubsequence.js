function solve(input) {
    let maxNumber = input.shift();
    const result = [maxNumber];

    input.forEach(e => 
        { 
            if(e >= maxNumber) {
                result.push(e);
                maxNumber = e;
            }
        });

    // let output = input.reduce((acc, val) => {
    //     if (val >= acc[acc.length - 1]) {
    //         acc.push(val);
    //     }
    //     return acc;
    // }, result);

    return result;
}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));
console.log(solve([20,
    3,
    2,
    15,
    6,
    1]
));