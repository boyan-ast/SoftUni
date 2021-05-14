function solve(n, k) {
    const sequence = [1];

    for (let i = 1; i < n; i++) {
        let element = calculateElement(sequence, k, i);

        sequence[i] = element;
    }

    return sequence;

    function calculateElement(elements, count, index) {
        let sum = 0;
        for (let i = index - 1; i >= Math.max(0, index - count); i--) {
            sum += elements[i];
        }

        return sum;
    }
}

console.log(solve(6, 3));