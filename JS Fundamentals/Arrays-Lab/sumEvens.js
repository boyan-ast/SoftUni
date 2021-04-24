function solve(elements) {
    let evenElements = elements.map(e => Number(e)).filter(e => e % 2 == 0);
    let sum = 0;

    for (let num of evenElements) {
        sum += num;
    }

    console.log(sum);
}

solve(['3','5','7','9']);