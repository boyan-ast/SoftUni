function solve(grade) {
    if (grade >= 5.50) {
        return 'Excellent';
    } else {
        return 'Not excellent';
    }
}

console.log(solve(4));
console.log(solve(5.67));