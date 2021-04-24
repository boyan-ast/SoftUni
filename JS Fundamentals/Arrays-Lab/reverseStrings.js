function solve(elements) {
    for (let i = 0; i < elements.length / 2; i++) {
        let temp = elements[i];
        elements[i] = elements[elements.length - 1 - i];
        elements[elements.length - 1 - i] = temp;
    }

    console.log(elements.join(' '));
}

solve(['abc', 'def', 'hig', 'klm', 'nop']);