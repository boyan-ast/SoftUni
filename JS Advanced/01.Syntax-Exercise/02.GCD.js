function solve(first, second) {
    for (let i = Math.min(first, second); i > 0; i--) {
        if (first % i == 0 && second % i == 0) {
            return i;
        }
    }
}


console.log(solve(15, 5));
console.log(solve(2154, 458));