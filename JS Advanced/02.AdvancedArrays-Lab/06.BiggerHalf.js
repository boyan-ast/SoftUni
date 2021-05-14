function biggerHalf(numbers) {
    const result = numbers.sort((a, b) => a - b).slice(numbers.length / 2);
    
    return result;
}

console.log(biggerHalf([4, 7, 2, 5, 8]));