function solve(inputArr) {
    const resultArr = inputArr
        .filter((e, i) => i % 2 == 1)
        .map(e => e * 2)
        .reverse();

    return resultArr.join(' ');
}

console.log(solve([3, 0, 10, 4, 7, 3]));