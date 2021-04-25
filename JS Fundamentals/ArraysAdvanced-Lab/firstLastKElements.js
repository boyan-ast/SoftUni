function solve(elements) {
    let k = elements[0];
    let firstElements = elements.slice(1, k + 1);
    let lastElements = elements.slice(-k);

    console.log(firstElements.join(' '));
    console.log(lastElements.join(' '));
}

solve([2, 7, 8, 9]);