function solve(numbers) {
    let result = numbers
                .filter((n, i) => i % 2 == 1)
                .map(n => n * 2)
                .reverse();

    console.log(result.join(' '));
}

solve([3, 0, 10, 4, 7, 3]);