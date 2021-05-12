function solve(elements) {
    console.log(sum(elements));
    console.log(sumInverse(elements));
    console.log(concat(elements));

    function sum(elements) {
        return elements.reduce((a, b) => a + b, 0);
    }

    function sumInverse(elements) {
        return elements.reduce((a, b) => a + 1/b, 0);
    }

    function concat(elements) {
        return elements.reduce((a, b) => a + b.toString(), 0).substring(1);
    }
}

solve([2, 4, 8, 16]);