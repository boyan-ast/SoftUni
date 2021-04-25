function solve(n, k) {
    let sequence = [1];

    for (let i = 1; i < n; i++) {
        let start = Math.max(0, i - k);
        let end = i;
        sequence[i] = sumElements(start, end);
    }

    console.log(sequence.join(' '));

    function sumElements(start, end) { 
        let sum = 0;
        for(let i = start; i < end; i ++) {
            sum += sequence[i];
        }

        return sum;
    }
}

solve(8, 2);