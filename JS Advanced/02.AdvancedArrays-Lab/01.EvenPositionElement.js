function solve(inputArr) {
    const resultArr = [];

    for (let i = 0; i < inputArr.length; i++) {
        if (i % 2 == 0) {
            resultArr.push(inputArr[i]);
        }
    }

    return resultArr.join(' ');
}

console.log(solve(['20', '30', '40', '50', '60']));