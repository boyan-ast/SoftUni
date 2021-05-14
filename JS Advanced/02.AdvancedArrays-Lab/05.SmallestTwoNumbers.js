function smallestTwoNumbers(numbers) {
    const smallestTwo = numbers.sort((a, b) => a-b).slice(0, 2);
    return smallestTwo.join(' ');    
}

console.log(smallestTwoNumbers([3, 0, 10, 4, 7, 3]));