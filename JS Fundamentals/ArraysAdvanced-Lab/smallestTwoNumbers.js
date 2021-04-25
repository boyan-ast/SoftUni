function solve(numbers) {
    let sorted = numbers.sort((a, b) => a - b);
    sorted.length = 2;
    console.log(sorted.join(' '));
}

solve([3, 0, 10, 4, 7, 3]);