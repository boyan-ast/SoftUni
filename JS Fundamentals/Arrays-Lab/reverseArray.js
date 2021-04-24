function reverse(n, numbers) {
    let result = numbers.slice(0, n).reverse();

    let output = '';

    for(let i = 0; i < result.length; i++){
        output += result[i] + ' ';
    }

    console.log(output);
}

reverse(3, [10, 20, 30, 40, 50]);
reverse(4, [-1, 20, 99, 5]);
reverse(2, [66, 43, 75, 89, 47]);