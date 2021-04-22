function solve(n) {
    let count = 0;
    let num = 1;
    let sum = 0;

    while (count < n) {
        console.log(num);
        sum += num;
        count++;
        num += 2;
    }

    console.log(`Sum: ${sum}`);
}

solve(3);