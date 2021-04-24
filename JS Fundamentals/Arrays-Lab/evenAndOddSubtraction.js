function subtraction(elements) {
    let evens = elements.filter(e => e % 2 == 0);
    let odds = elements.filter(e => e % 2 != 0);

    return sum(evens) - sum(odds);

    function sum(numbers) {
        let sum = 0;

        for (let i = 0; i < numbers.length; i++) {
            sum += numbers[i];            
        }

        return sum;
    }
}

